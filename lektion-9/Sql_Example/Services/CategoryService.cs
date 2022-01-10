using Sql_Example.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Example.Services
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
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-9\Sql_Example\Data\sql_example_db.mdf;Integrated Security=True;Connect Timeout=30";


        public void Create(string name)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Categories WHERE Name = @CategoryName) INSERT INTO Categories VALUES (@CategoryName)", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Category Get(int id)
        {
            var category = new Category();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE Id = @CategoryId", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", id);
                    var result = cmd.ExecuteReader();

                    while(result.Read())
                    {
                        category.Id = (int)result.GetValue(0);
                        category.Name = (string)result.GetValue(1);
                    };
                }
            }

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        categories.Add(new Category
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1)
                        });
                    };
                }
            }

            return categories;
        }

        public Category GetByName(string name)
        {
            var category = new Category();

            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE Name = @CategoryName", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", name);
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        category.Id = (int)result.GetValue(0);
                        category.Name = (string)result.GetValue(1);
                    };
                }
            }

            return category;
        }
    }
}
