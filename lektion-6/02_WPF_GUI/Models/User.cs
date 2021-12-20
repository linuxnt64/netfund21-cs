using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WPF_GUI.Models
{
    internal class User
    {
        private string _email;


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get { return _email; } set { _email = value.ToLower(); } }
        public string Password { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
        public string PostalCodeAndCity => $"{PostalCode} {City}";
    }
}
