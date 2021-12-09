using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Classes.Models
{
    internal class Participant
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }   
        public string Email { get; set; }
        public string SpecialRequests { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
