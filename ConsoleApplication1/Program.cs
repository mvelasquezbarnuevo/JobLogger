using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobLoger = new JobLogger2(true, true, false);

            jobLoger.LogAsMessage("test1 ");
            jobLoger.LogAsWarning("test2");
            jobLoger.LogAsError("test3");

            Console.ReadKey();
        }
    }
}
