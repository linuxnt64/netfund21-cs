using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2.Models
{
    internal class Participant
    {
        public Participant()
        {

        }

        public Participant(string firstName, string lastName, string email, string specialRequest)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SpecialRequest = specialRequest;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SpecialRequest { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
