using ConsoleApplication1.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LoggerDataBase : ILogDestination
    {
        public LoggerDataBase()
        {
            _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }


        public void WriteMessage(string message, LogType type)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("missing connection string");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = string.Format("Insert  into  Log  Values('{0}','{1}')", message, type);
                SqlCommand command = new SqlCommand(query);
                command.ExecuteNonQuery();
            }
        }

        private string _connectionString = "";
    }
}
