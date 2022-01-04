using _02_SqlStorage_Recap.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Managers
{
    public class ProductManager
    {
        private static string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-8\02_SqlStorage_Recap\Data\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        CategoryHandler categoryHandler = new CategoryHandler(connectionstring);
        ProductHandler productHandler = new ProductHandler(connectionstring);

        public void CreateProduct(string name, string description, decimal price, string category)
        {
            var categoryId = categoryHandler.Create(category);
            var productId = productHandler.Create(name, description, price, categoryId);
            Console.WriteLine(productId);
        }
    }
}
