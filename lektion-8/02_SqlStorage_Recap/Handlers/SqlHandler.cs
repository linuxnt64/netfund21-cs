using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Handlers
{
    public abstract class SqlHandler
    {
        protected string _connectionString;

        protected virtual object Insert(string query, Dictionary<string, object> values)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            foreach (var value in values)
                cmd.Parameters.AddWithValue(value.Key, value.Value);

            return cmd.ExecuteScalar();
        }

    }
}
