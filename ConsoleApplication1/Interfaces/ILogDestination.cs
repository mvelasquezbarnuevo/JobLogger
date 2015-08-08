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

        void WriteMessage(string message, LogType type);
    }
}
