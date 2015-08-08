using ConsoleApplication1;
using ConsoleApplication1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Injectors
{

    public class BaseTest : ILogDestination, ITest
    {
        public void WriteLog(string message, LogType type, List<LogType> _canBeLogged)
        {
            _results.Add(new TestResult { Message = message, LogType = type });
        }

        public List<TestResult> GetResults()
        {
            return _results;
        }

        private List<TestResult> _results = new List<TestResult>();
    }



}
