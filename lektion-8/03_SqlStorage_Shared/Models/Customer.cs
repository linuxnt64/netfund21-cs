using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SqlStorage_Shared.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int AddressId { get; set; }
    }
}
