using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Handlers
{
    public class ProductHandler : SqlHandler 
    {
        public ProductHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(string name, string description, decimal price, int categoryId)
        {
            var query = "IF NOT EXISTS(SELECT Id FROM Products WHERE Name = @ProductName) INSERT INTO Products OUTPUT inserted.Id VALUES (@CategoryId, @ProductName, @ProductDescription, @ProductPrice) ELSE SELECT Id FROM Products WHERE Name = @ProductName";
            var dictionary = new Dictionary<string, object>
            {
                { "@ProductName", name },
                { "@ProductDescription", description },
                { "@ProductPrice", price },
                { "@CategoryId", categoryId }
            };

            return (int)Insert(query, dictionary);
        }
    }
}
