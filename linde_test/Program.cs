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
                Escenario escenario = new Escenario(Environment.GetCommandLineArgs()[1]);
                Console.WriteLine(escenario.Properties.Battery);
                Console.WriteLine(escenario.Properties.Commands);
                Console.WriteLine(escenario.Properties.InitialPosition.Location.X);
                Console.WriteLine(escenario.Properties.Terrain);
                Console.ReadLine();
            }
            else
            {
                //string outputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_sol_1_paco.json";

                string inputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_run_1.json";
                Escenario escenario = new Escenario(inputPath);

                Robot robot = new Robot(escenario.Properties.InitialPosition)
                {
                    Battery = escenario.Properties.Battery,
                    Commands = escenario.Properties.Commands,
                    Map = new Map(escenario.Properties.Terrain)
                };

                robot.ExecuteCommands();
            }
            Console.ReadLine();
        }
    }
}
