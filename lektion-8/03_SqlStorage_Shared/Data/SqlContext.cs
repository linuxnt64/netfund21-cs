using _03_SqlStorage_Shared.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SqlStorage_Shared.Data
{
    public class SqlContext
    {
        private string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-8\03_SqlStorage_Shared\Data\sql_db2.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection _conn;
        private IDbConnection _connDapper;

        protected virtual void Connect()
        {        
            _conn = new SqlConnection(_connectionstring);
            _connDapper = new SqlConnection(_connectionstring);
        }

        protected virtual object Execute(string query, Dictionary<string, object> values)
        {
            Connect();
            _conn.Open();
            using var cmd = new SqlCommand(query, _conn);
            foreach (var value in values)
                cmd.Parameters.AddWithValue(value.Key, value.Value);
            
            var result = cmd.ExecuteScalar();
            _conn.Close();

            return result;
        }

        protected virtual int ExecuteWithDapper(string query, object data)
        {
            Connect();
            _connDapper.Open();
            var result = (int)_connDapper.ExecuteScalar(query, data);

            return result;
        }
    }
}
