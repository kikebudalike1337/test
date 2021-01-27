using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePraksa.Api.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public int YearOfStudy { get; set; }
        public string Course { get; set; }
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Admin { get; set; }
    }
}
