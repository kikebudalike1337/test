using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePraksa.Api.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfStudy { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserID { get; set; }

    }
}
