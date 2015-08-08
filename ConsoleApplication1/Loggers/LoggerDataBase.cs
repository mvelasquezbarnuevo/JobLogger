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

        public void WriteLog(string message, LogType logType, List<LogType> _canBeLogged)
        {
            if (_canBeLogged.Contains(logType))
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new ArgumentNullException(Messages.Validation.MissingConfig);
                }
                DataBase.InsertRecord(message, (int)logType);
            }
        }

        private DataBaseHelper _dataBase;
        private DataBaseHelper DataBase
        {
            get {
                if (_dataBase == null)
                {
                    _dataBase = new DataBaseHelper(_connectionString);
                }

                return _dataBase;
            }
        }
        private string _connectionString = "";

    }
}
