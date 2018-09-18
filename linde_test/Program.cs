using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using linde_test.Classes.Escenario;

namespace linde_test
{
    class Program
    {
     

        static void Main(string[] args)
        {
            bool testing = true;

            if (!testing)
            {
                 InitEscenario escenario = new InitEscenario(Environment.GetCommandLineArgs()[1]);
            }
            else
            {
                string inputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_run_1.json";
                string outputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_sol_1_paco.json";
                InitEscenario escenario = new InitEscenario(inputPath);
            }
           



        
            Console.ReadLine();
        }
    }
}
