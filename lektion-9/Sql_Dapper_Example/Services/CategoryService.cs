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
    internal interface ICategoryService
    {
        void Create(string name);
        Category Get(int id);
        Category GetByName(string name);
        IEnumerable<Category> GetAll();
    }

    internal class CategoryService : ICategoryService
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-9\Sql_Dapper_Example\Data\sql_dapper_example.mdf;Integrated Security=True;Connect Timeout=30";


        public void Create(string name)
        {
            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Execute("IF NOT EXISTS (SELECT Id FROM Categories WHERE Name = @CategoryName) INSERT INTO Categories VALUES (@CategoryName)", new { CategoryName = name });
            }
        }

        public Category Get(int id)
        {
            var category = new Category();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                category = conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Id = @CategoryId", new { CategoryId = id });
            }

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                categories = conn.Query<Category>("SELECT * FROM Categories").ToList();
            }

            return categories;
        }

        public Category GetByName(string name)
        {
            var category = new Category();

            using (IDbConnection conn = new SqlConnection(_connectionstring))
            {
                category = conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Name = @CategoryName", new { CategoryName = name });
            }

            return category;
        }
    }
}
