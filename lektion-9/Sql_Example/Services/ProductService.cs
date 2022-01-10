using Sql_Example.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Example.Services
{
    internal interface IProductService
    {
        void Create(string name, string description, decimal price, int categoryId);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }

    internal class ProductService : IProductService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-9\Sql_Example\Data\sql_example_db.mdf;Integrated Security=True;Connect Timeout=30";


        public void Create(string name, string description, decimal price, int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @ProductName) INSERT INTO Products VALUES (@ProductName, @ProductDescription, @ProductPrice, @CategoryId)", conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", name);
                    cmd.Parameters.AddWithValue("@ProductDescription", description);
                    cmd.Parameters.AddWithValue("@ProductPrice", price);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Product Get(int id)
        {
            var product = new Product();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Name, p.Description, p.Price,c.Name as Category FROM Products p JOIN Categories c ON c.Id = p.CategoryId WHERE p.Id = @ProductId", conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        product.Id = (int)result.GetValue(0);
                        product.Name = (string)result.GetValue(1);
                        product.Description = (string)result.GetValue(2);
                        product.Price = (decimal)result.GetValue(3);
                        product.Category = (string)result.GetValue(4);
                    };
                }
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Name, p.Description, p.Price,c.Name as Category FROM Products p JOIN Categories c ON c.Id = p.CategoryId", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1),
                            Description = (string)result.GetValue(2),
                            Price = (decimal)result.GetValue(3),
                            Category = (string)result.GetValue(4)
                        });
                    };
                }
            }

            return products;
        }
    }
}
