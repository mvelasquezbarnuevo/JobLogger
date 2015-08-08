using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApplication1.Helpers;

namespace ConsoleApplication1
{
    public class LoggerFile : ILogDestination
    {
        
        public LoggerFile()
        {
            _fileLocation = ConfigurationManager.AppSettings["LogFileDirectory"];
            _fileURL = string.Format("{0}LogFile_{1:yyyy-MM-dd}.txt", _fileLocation, DateTime.Now);
        }

        public void WriteLog(string message, LogType logType, List<LogType> _canBeLogged)
        {
            if (_canBeLogged.Contains(logType))
            {
                ValidateURL();

                string fileContent = "";
                if (File.Exists(_fileURL))
                {
                    //get contents and append data
                    fileContent = File.ReadAllText(_fileURL);
                }

                fileContent += string.Format("{0}{1}", DateTime.Now.ToShortDateString(), message) + Environment.NewLine;
                File.WriteAllText(_fileURL, fileContent);
            }
        }

        private void ValidateURL()
        {
           

            if (string.IsNullOrEmpty(_fileURL))
            {
                throw new ArgumentNullException(Messages.Validation.MissingFile);
            }


            if (!Directory.Exists(_fileLocation))
                Directory.CreateDirectory(_fileLocation);
           
        }

        private string _fileURL = "";
        private string _fileLocation = "";

    }

}
