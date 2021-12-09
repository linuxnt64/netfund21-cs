using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Exersice2_Example.Models
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
