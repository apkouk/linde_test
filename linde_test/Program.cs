using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linde_test
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] argus = Environment.GetCommandLineArgs();
           


            Console.WriteLine(argus[1].ToString());
            Console.WriteLine(argus[2].ToString());
            Console.ReadLine();
        }
    }
}
