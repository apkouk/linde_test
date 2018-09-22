﻿using System;
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
                escenario = new Escenario(Environment.GetCommandLineArgs()[1], Environment.GetCommandLineArgs()[2]);
                robot = new Robot(escenario);
                robot.ExecuteCommands();
                robot.WriteOutput();
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
