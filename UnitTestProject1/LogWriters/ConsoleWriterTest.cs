using System;
using System.Collections.Generic;
using ConsoleApplication1.Interfaces;

namespace UnitTestProject1.LogWriters
{
    public class ConsoleWriterTest : IConsoleWriter
    {
        public void WriteToConsole(string message, ConsoleColor consoleColor)
        {
            ConsoleWriterResult.Add(new ConsoleWriterResult { Message = message, ConsoleColor = consoleColor});
        }

        public void WriteToConsole(string message)
        {
            ConsoleWriterResult.Add(new ConsoleWriterResult{Message = message});
        }

        public List<ConsoleWriterResult> ConsoleWriterResult = new List<ConsoleWriterResult>();
    }

    public class ConsoleWriterResult
    {
        public string Message { get; set; }
        public ConsoleColor? ConsoleColor { get; set; }
    }
}
