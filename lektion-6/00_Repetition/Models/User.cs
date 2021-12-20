using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Models
{
    internal class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        

        public string DisplayName => $"{FirstName} {LastName}";
        public string Address { get { return $"{AddressLine}, {PostalCode} {City}"; } }


        private string Hash { get; set; }
        private string Salt { get; set; }

        public void CreatePassword(string password)
        {
            Hash = password;
            Salt = password;
        }

        public bool ValidatePassword(string password)
        {
            if (Hash == password)
                return true;
            
            return false;
        }
    }
}
