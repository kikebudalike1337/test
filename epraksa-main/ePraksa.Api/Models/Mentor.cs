using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePraksa.Api.Models
{
    public class Mentor
    {

        public int MentorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
    }
}
