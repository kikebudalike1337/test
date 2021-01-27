using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePraksa.Api.Models
{
    public class BaseContext : IdentityDbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options):base(options)
        {

        }


        public DbSet<Student>Students { get; set; }
        public DbSet<Mentor>Mentors { get; set; }
        public DbSet<Company>Companies { get; set; }
        public DbSet<Internship>Internships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
