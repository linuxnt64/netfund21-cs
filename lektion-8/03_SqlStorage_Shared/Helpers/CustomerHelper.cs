using _03_SqlStorage_Shared.Data;
using _03_SqlStorage_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SqlStorage_Shared.Helpers
{
    public class CustomerHelper : SqlContext
    {
        public int Create(string firstname, string lastname, string email, int addressId)
        {
            var query = "IF NOT EXISTS(SELECT Id FROM Customers WHERE Email = @Email) IF EXISTS(SELECT Id FROM Addresses WHERE Id = @AddressId) INSERT INTO Customers OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT Id FROM Customers WHERE Email = @Email";
            var dictionary = new Dictionary<string, object>
            {
                { "@FirstName", firstname },
                { "@LastName", lastname },
                { "@Email", email },
                { "@AddressId", addressId }
            };

            return (int)Execute(query, dictionary);
        }
        public int CreateWithDapper(Customer customer)
        {
            var query = "IF NOT EXISTS(SELECT Id FROM Customers WHERE Email = @Email) IF EXISTS(SELECT Id FROM Addresses WHERE Id = @AddressId) INSERT INTO Customers OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT Id FROM Customers WHERE Email = @Email";
            return (int)ExecuteWithDapper(query, customer);
        }

    }
}
