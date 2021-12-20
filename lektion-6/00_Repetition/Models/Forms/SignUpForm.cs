using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Models.Forms
{
    internal class SignUpForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; } 
        public string City { get; set; }
    }
}
