using ConsoleApplication1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LoggerConsole : ILogDestination
    {
        public LoggerConsole()
        { 
        }

        public void WriteMessage(string message, LogType logType)
        {

            if (ConsoleColors.ContainsKey(logType))
                Console.ForegroundColor = ConsoleColors[logType];
            Console.WriteLine(string.Format("{0} {1}", DateTime.Now.ToShortDateString(), message));
        }

        private Dictionary<LogType, ConsoleColor> ConsoleColors = new Dictionary<LogType, ConsoleColor>
        {
            {LogType.Message, ConsoleColor.White},
            {LogType.Warning, ConsoleColor.Yellow},
            {LogType.Error, ConsoleColor.Red}
        };
    }

}
