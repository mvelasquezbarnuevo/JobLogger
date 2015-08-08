using ConsoleApplication1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ILogger
    {
         void LogAsMessage(string message);
         void LogAsWarning(string message);
         void LogAsError(string message);
         void LogMessage(string message, LogType logType);
       
    }
}
