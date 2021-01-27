using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePraksa.Api.Models
{
    public class Internship
    {
        public int internshipID { get; set; }
        public string internshipName { get; set; }
        public string internshipDescription { get; set; }
        public string mentorName { get; set; }
        public DateTime internshipStartDate { get; set; }
        public DateTime internshipEndDate { get; set; }
        public string mentorContactEmail { get; set; }
    }
}
