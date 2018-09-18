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
            InitEscenario escenario = new InitEscenario(Environment.GetCommandLineArgs()[1]);



        
            Console.ReadLine();
        }
    }
}
