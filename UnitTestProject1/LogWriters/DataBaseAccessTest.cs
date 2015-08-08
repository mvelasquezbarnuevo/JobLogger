using System.Collections.Generic;
using ConsoleApplication1.Interfaces;

namespace UnitTestProject1.LogWriters
{
    public class DataBaseAccessTest : IDataBaseAccess
    {
        public void SaveChanges(string message, int type)
        {
            DataBaseAccessResult.Add(new DataBaseAccessResult { Message = message, Type = type });
        }

        public List<DataBaseAccessResult> DataBaseAccessResult = new List<DataBaseAccessResult>();
    }
    public class DataBaseAccessResult
    {
        public string Message { get; set; }
        public int Type { get; set; }
    }
}
