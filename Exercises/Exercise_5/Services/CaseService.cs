using Dapper;
using Exercise_5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5.Services
{
    internal interface ICaseService
    {
        void CreateCase(Case data);
        Case GetCase(int id);
        IEnumerable<Case> GetAllCases();
        
        void CreateCustomer(Customer data);
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();

        void CreateStatusType(StatusType data);
        StatusType GetStatusType(int id);
        IEnumerable<StatusType> GetAllStatusTypes();

    }

    internal class CaseService : ICaseService
    {
        private readonly string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\Exercises\Exercise_5\Data\exercise_5_db.mdf;Integrated Security=True;Connect Timeout=30"; 

        public void CreateCase(Case data)
        {
            data.CreatedDate = DateTime.Now;

            using IDbConnection conn = new SqlConnection(connectionstring);
            conn.Execute("INSERT INTO Cases VALUES (@CustomerId,@StatusTypeId,@Title,@Description,@CreatedDate)", data);
            conn.Close();
        }

        public void CreateCustomer(Customer data)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            conn.Execute("INSERT INTO Customers VALUES (@FirstName,@LastName,@Email)", data);
            conn.Close();
        }

        public void CreateStatusType(StatusType data)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            conn.Execute("INSERT INTO StatusTypes VALUES (@Status)", data);
            conn.Close();
        }

        public IEnumerable<Case> GetAllCases()
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var items = conn.Query<Case>("SELECT * FROM Cases");
            conn.Close();

            return items;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var items = conn.Query<Customer>("SELECT * FROM Customers");
            conn.Close();

            return items;
        }

        public IEnumerable<StatusType> GetAllStatusTypes()
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var items = conn.Query<StatusType>("SELECT * FROM StatusTypes");
            conn.Close();

            return items;
        }

        public Case GetCase(int id)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var item = conn.QueryFirstOrDefault<Case>("SELECT * FROM Cases WHERE Id = @Id", new { Id = id });
            conn.Close();
            return item;
        }

        public Customer GetCustomer(int id)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var item = conn.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
            conn.Close();
            return item;
        }

        public Customer GetCustomer(string email)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var item = conn.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE Email = @Email", new { Email = email });
            conn.Close();
            return item;
        }

        public StatusType GetStatusType(int id)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var item = conn.QueryFirstOrDefault<StatusType>("SELECT * FROM StatusTypes WHERE Id = @Id", new { Id = id });
            conn.Close();
            return item;
        }

        public StatusType GetStatusType(string status)
        {
            using IDbConnection conn = new SqlConnection(connectionstring);
            var item = conn.QueryFirstOrDefault<StatusType>("SELECT * FROM StatusTypes WHERE Status = @Status", new { Status = status });
            conn.Close();
            return item;
        }
    }
}
