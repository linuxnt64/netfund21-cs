using Dapper;
using Sql_Dapper_Example.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Dapper_Example.Services
{
    internal interface IProductService
    {
        void Create(string name, string description, decimal price, int categoryId);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }

    internal class ProductService : IProductService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-9\Sql_Dapper_Example\Data\sql_dapper_example.mdf;Integrated Security=True;Connect Timeout=30";


        public void Create(string name, string description, decimal price, int categoryId)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Execute("IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @ProductName) INSERT INTO Products VALUES (@ProductName, @ProductDescription, @ProductPrice, @CategoryId)", new { ProductName = name, ProductDescription = description, ProductPrice = price, CategoryId = categoryId });
            }
        }

        public Product Get(int id)
        {
            var product = new Product();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                product = conn.QueryFirstOrDefault<Product>("SELECT p.Id, p.Name, p.Description, p.Price,c.Name as Category FROM Products p JOIN Categories c ON c.Id = p.CategoryId WHERE p.Id = @ProductId", new { ProductId = id });
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                products = conn.Query<Product>("SELECT p.Id, p.Name, p.Description, p.Price,c.Name as Category FROM Products p JOIN Categories c ON c.Id = p.CategoryId").ToList();
            }

            return products;
        }
    }
}
