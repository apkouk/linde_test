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
                Escenario escenario = new Escenario(Environment.GetCommandLineArgs()[1], Environment.GetCommandLineArgs()[2]);
                Robot robot = new Robot(escenario);
                robot.ExecuteCommands();
            }
            else
            {
                string outputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_sol_1_paco.json";
                string inputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_run_1.json";
                Escenario escenario = new Escenario(inputPath, outputPath);

                Robot robot = new Robot(escenario);
                robot.ExecuteCommands();
                robot.ExecuteCommand("F");
            }
            Console.ReadLine();
        }
    }
}
