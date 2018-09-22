using System;
using System.IO;
using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Escenario escenario;
            IRobot robot;

            if (Properties.Settings.Default.Production)
            {
                try
                {
                    if (Environment.GetCommandLineArgs()[1] != null && Environment.GetCommandLineArgs()[2] != null)
                    {
                        if (File.Exists(Environment.GetCommandLineArgs()[1]) && File.Exists(Environment.GetCommandLineArgs()[2]))
                        {
                            escenario = new Escenario(Environment.GetCommandLineArgs()[1], Environment.GetCommandLineArgs()[2]);
                            robot = new Robot(escenario);
                            robot.ExecuteCommands();
                            robot.WriteOutput();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("You need to pass two parameters (json file path) to make it work! \n(Press any key to continue)");
                    Console.ReadLine();
                }
            }
            else
            {
                escenario = new Escenario(Properties.Settings.Default.InputPath, Properties.Settings.Default.OutputPath);
                robot = new Robot(escenario);
                robot.ExecuteCommands();
                robot.WriteOutput();
            }
        }
    }
}
