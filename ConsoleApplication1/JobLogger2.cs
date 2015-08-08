using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Helpers;

namespace ConsoleApplication1
{
    public class JobLogger2 : ILogger
    {

        public void LogAsMessage(string message)
        {
            LogMessage(message, LogType.Message);
        }

        public void LogAsWarning(string message)
        {
            LogMessage(message, LogType.Warning);
        }

        public void LogAsError(string message)
        {
            LogMessage(message, LogType.Error);
        }

        public void LogMessage(string message, LogType logType)
        {

            if (string.IsNullOrWhiteSpace(message))
                return;
            message = message.Trim();

            ValidateLogDestination();

            if (LogToConsole)
                WriteMessage(message, logType, LoggerConsole);
            if (LogToFile)
                WriteMessage(message, logType, LoggerFile);
            if (LogToDatabase)
                WriteMessage(message, logType, LoggerDataBase);

        }

        public void WriteMessage(string message, LogType logType, ILogDestination logDestination)
        {
            logDestination.WriteLog(message, logType, typesThatCanBeLogged());
        }




        public JobLogger2(bool logToConsole, bool logToFile, bool logToDatabase, bool logOnlyErrors)
        {
            LogToFile = logToFile;
            LogToConsole = logToConsole;
            LogToDatabase = logToDatabase;
            _logOnlyErrors = logOnlyErrors;
        }

        public bool LogToFile { get; private set; }
        public bool LogToConsole { get; private set; }
        public bool LogToDatabase { get; private set; }

        private List<LogType> typesThatCanBeLogged()
        {
            List<LogType> types = new List<LogType>();

            types.Add(LogType.Message);
            if (_logOnlyErrors)
            {
                types.Add(LogType.Error);
            }
            else
            {
                types.Add(LogType.Warning);
                types.Add(LogType.Error);
            }
            return types;
        }

        private ILogDestination _loggerConsole;
        public ILogDestination LoggerConsole
        {
            get
            {
                if (_loggerConsole == null)
                    _loggerConsole = new LoggerConsole();
                return _loggerConsole;
            }
            set
            {
                _loggerConsole = value;
            }
        }
        private ILogDestination _loggerFile;
        public ILogDestination LoggerFile
        {
            get
            {
                if (_loggerFile == null)
                    _loggerFile = new LoggerFile();
                return _loggerFile;
            }
            set
            {
                _loggerFile = value;
            }
        }
        private ILogDestination _loggerDataBase;
        public ILogDestination LoggerDataBase
        {
            get
            {
                if (_loggerDataBase == null)
                    _loggerDataBase = new LoggerDataBase();
                return _loggerDataBase;
            }
            set
            {
                _loggerDataBase = value;
            }
        }

        private void ValidateLogDestination()
        {
            if (AllConfigurationNotInFalse())
                return;
            throw new Exception("Invalid  configuration");
        }
        private bool AllConfigurationNotInFalse()
        {
            return LogToConsole
                   || LogToFile
                   || LogToDatabase;
        }

        private bool _logOnlyErrors;
    }
}


