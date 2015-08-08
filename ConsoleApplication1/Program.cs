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
            var jobLoger = new JobLogger2(true, true, false, true);
            jobLoger.LogAsMessage("   ");
            jobLoger.LogAsMessage("this is a message   ");
            jobLoger.LogAsWarning("this is a warning");
            jobLoger.LogAsError("this is an error");

  
            Console.ReadKey();
        }
    }


}
