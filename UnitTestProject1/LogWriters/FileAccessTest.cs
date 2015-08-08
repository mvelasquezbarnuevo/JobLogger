using System.Collections.Generic;
using ConsoleApplication1.Interfaces;

namespace UnitTestProject1.LogWriters
{
    public class FileAccessTest : IFileAccess
    {
        public void WriteToFile(string text)
        {
            FileAccessResult .Add(text);
        }

        public List<string> FileAccessResult = new List<string>();
    }
}
