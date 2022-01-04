using _03_SqlStorage_Shared.Helpers;
using _03_SqlStorage_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SqlStorage_Shared.Handlers
{
    public class CustomerHandler
    {
        AddressHelper _address = new AddressHelper();
        CustomerHelper _customer = new CustomerHelper();

        public int Create(string firstname, string lastname, string email, string addressline, string postalcode, string city)
        {
            var addressId = _address.Create(addressline, postalcode, city);
            var customerId = _customer.Create(firstname, lastname, email, addressId);
            return customerId;
        }

        public int Create(Customer customer)
        {
            customer.AddressId = _address.Create(customer.AddressLine, customer.PostalCode, customer.City);
            var customerId = _customer.CreateWithDapper(customer);
            return customerId;
        }
    }
}
