using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Handlers
{
    public class CategoryHandler : SqlHandler
    {
        public CategoryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(string categoryName)
        {
            var query = "IF NOT EXISTS(SELECT Id FROM Categories WHERE Name = @CategoryName) INSERT INTO Categories OUTPUT inserted.Id VALUES (@CategoryName) ELSE SELECT Id FROM Categories WHERE Name = @CategoryName";
            var dictionary = new Dictionary<string, object>
            {
                { "@CategoryName", categoryName }
            };

            return (int)Insert(query, dictionary);
        }
    }
}
