using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Handlers
{
    public class AddressHandler : SqlHandler
    {
        public AddressHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(string addressline, string postalcode, string city)
        {
            var query = "IF NOT EXISTS(SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@AddressLine, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode";
            var dictionary = new Dictionary<string, object>
            {
                { "@AddressLine", addressline },
                { "@PostalCode", postalcode.Replace(" ","") },
                { "@City", city }
            };

            return (int)Insert(query, dictionary);
        }
    }
}
