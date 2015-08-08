using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Helpers
{
    public class DataBaseHelper
    {

        public DataBaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertRecord(string message, int severity)
        {
            string query = "Insert  into  Log (Message, Severity) Values (@Message, @Severity) ";

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // parameters and values
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Value = message;
                cmd.Parameters.Add("@Severity", SqlDbType.Int).Value = severity;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        private string _connectionString = "";
    }
}
