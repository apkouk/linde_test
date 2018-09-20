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
            Escenario escenario = new Escenario(Environment.GetCommandLineArgs()[1], Environment.GetCommandLineArgs()[2]);
            Robot robot = new Robot(escenario);
            robot.ExecuteCommands();
        }
    }
}
