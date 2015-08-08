using ConsoleApplication1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ILogDestination
    {

        void WriteLog(string message, LogType type, List<LogType> _canBeLogged);
    }
}
