using ePraksa.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ePraksa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        private readonly BaseContext _context;
        public UserController(UserManager<IdentityUser> userManager, IConfiguration configuration, BaseContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }
        // POST: api/User/Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            
            var applicationUser = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            

            if (model.Password != model.ConfirmPassword)
                return BadRequest();
            try
            {
                //create user in aspnetroles
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);


                //model for student in table
                var studentUser = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    YearOfStudy = model.YearOfStudy,
                    Course = model.Course,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserID = applicationUser.Id

                };
                //model for mentor in table 
                var mentorUser = new Mentor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CompanyName = model.CompanyName,
                    Email = model.Email,
                    ContactNumber = model.PhoneNumber,
                    UserID = applicationUser.Id

                };

                if(model.Role == "mentor")
                {
                    //create mentor in table
                    _context.Mentors.Add(mentorUser);
                    await _context.SaveChangesAsync();

                }
                else if(model.Role == "student"){
                    //create student in table
                    _context.Students.Add(studentUser);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return Ok(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        // POST: api/User/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //getting role from db
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                //setting claims

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["AuthSettings:Issuer"],
                    Audience = _configuration["AuthSettings:Audience"],
                    Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                   }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"])), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message ="Username or password incorrect"});
            }
        }
    }
}
