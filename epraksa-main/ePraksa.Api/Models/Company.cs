using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePraksa.Api.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Notes { get; set; }
        public string MentorsID { get; set; }
    }
}

