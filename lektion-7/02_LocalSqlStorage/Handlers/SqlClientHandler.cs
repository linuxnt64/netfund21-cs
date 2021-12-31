using _02_LocalSqlStorage.Interfaces;
using _02_LocalSqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Handlers
{

    public interface ISqlClientHandler : IProductSqlCommands, ICustomerSqlCommands, IOrderSqlCommands
    {

    }


    public class SqlClientHandler : ISqlClientHandler
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-7\02_LocalSqlStorage\Data\sql_database.mdf;Integrated Security=True;Connect Timeout=30";

        public void SaveProduct(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products (Name, Description, StockPrice) VALUES (@Name, @Description, @StockPrice)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@StockPrice", product.StockPrice);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Products", conn))
                {
                    var result = cmd.ExecuteReader();

                    while(result.Read())
                    {
                        products.Add(new Product
                        {
                            Id = int.Parse(result.GetValue(0).ToString()),
                            Name = result.GetValue(1).ToString(),
                            Description = result.GetValue(2).ToString(),
                            StockPrice = decimal.Parse(result.GetValue(3).ToString())
                        });
                    }
                }
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            var product = new Product();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {

                        product.Id = int.Parse(result.GetValue(0).ToString());
                        product.Name = result.GetValue(1).ToString();
                        product.Description = result.GetValue(2).ToString();
                        product.StockPrice = decimal.Parse(result.GetValue(3).ToString());

                    }
                }
            }

            return product;
        }

        public void SaveCustomer(Customer customer, string password)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Customer GetCustomer(int id)
        {
            var customer = new Customer();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Id, FirstName, LastName, Email FROM Customers WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {

                        customer.Id = int.Parse(result.GetValue(0).ToString());
                        customer.FirstName = result.GetValue(1).ToString();
                        customer.LastName = result.GetValue(2).ToString();
                        customer.Email = result.GetValue(3).ToString();

                    }
                }
            }

            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Id, FirstName, LastName, Email FROM Customers", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = int.Parse(result.GetValue(0).ToString()),
                            FirstName = result.GetValue(1).ToString(),
                            LastName = result.GetValue(2).ToString(),
                            Email = result.GetValue(3).ToString()
                        });
                    }
                }
            }

            return customers;
        }





        public void SaveOrder(ShoppingCart shoppingCart)
        {
            var order = new Order();

            foreach(var item in shoppingCart.Items)
            {
                order.TotalPrice += (item.Price * item.Quantity);
            }

            order.VAT = order.TotalPrice * 0.2m;

            using (var conn = new SqlConnection(_connectionString))
            {
                var orderId = 0;

                conn.Open();
                using (var cmd = new SqlCommand("IF EXISTS (SELECT Id FROM Customers WHERE Id = @CustomerId) INSERT INTO Orders (CustomerId, OrderDate, DueDate, VAT, TotalPrice) OUTPUT Inserted.Id VALUES (@CustomerId, @OrderDate, @DueDate, @VAT, @TotalPrice)", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", shoppingCart.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(30));
                    cmd.Parameters.AddWithValue("@VAT", order.VAT);
                    cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                    orderId = int.Parse(cmd.ExecuteScalar().ToString());
                    
                }

                foreach (var item in shoppingCart.Items)
                {
                    using(var cmd = new SqlCommand("INSERT INTO OrderRows (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)", conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@Price", (item.Price));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public Order GetOrder(int id)
        {
            var order = new Order();
            var customerId = 0;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Orders WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        order.Id = int.Parse(result.GetValue(0).ToString());
                        customerId = int.Parse(result.GetValue(1).ToString());
                        order.OrderDate = DateTime.Parse(result.GetValue(2).ToString());
                        order.DueDate = DateTime.Parse(result.GetValue(3).ToString());
                        order.VAT = decimal.Parse(result.GetValue(4).ToString());
                        order.TotalPrice = decimal.Parse(result.GetValue(5).ToString());
                    }


                }
            }
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Customers WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", customerId);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        order.Customer = new Customer
                        {
                            Id = int.Parse(result.GetValue(0).ToString()),
                            FirstName = result.GetValue(1).ToString(),
                            LastName = result.GetValue(2).ToString(),
                            Email = result.GetValue(3).ToString(),
                        };
                    }
                }
            }
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM OrderRows WHERE OrderId = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", order.Id);

                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        order.OrderRows.Add(new OrderRow
                        {
                            OrderId = int.Parse(result.GetValue(0).ToString()),
                            ProductId = int.Parse(result.GetValue(1).ToString()),
                            Quantity = int.Parse(result.GetValue(2).ToString()),
                            Price = decimal.Parse(result.GetValue(3).ToString())
                        }); 
                    }
                }

            }

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
