using _03_SqlStorage_Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SqlStorage_Shared.Helpers
{
    public class AddressHelper : SqlContext
    {
        public int Create(string addressline, string postalcode, string city)
        {
            var query = "IF NOT EXISTS(SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@AddressLine, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode";
            var dictionary = new Dictionary<string, object>
            {
                { "@AddressLine", addressline },
                { "@PostalCode", postalcode.Replace(" ","") },
                { "@City", city }
            };

            return (int)Execute(query, dictionary);
        }
    }
}
