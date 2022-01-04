using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Handlers
{
    public class CustomerHandler : SqlHandler
    {
        public CustomerHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

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

            return (int)Insert(query, dictionary);
        }
    }
}
