using System;
using linde_test.Classes.Escenario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace linde_ut
{
    [TestClass]
    public class RobotUT
    {
        [TestMethod]
        public void SholdMoveOneToTheRight()
        {
            string inputPath = @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_run_1.json";
            Escenario escenario = new Escenario(inputPath);

            Robot robot = new Robot(escenario.Properties.InitialPosition)
            {
                Battery = escenario.Properties.Battery,
                Commands = escenario.Properties.Commands,
                Map = new Map(escenario.Properties.Terrain)
            };

            robot.ExecuteCommand("F");
            robot.ExecuteCommand("F");
            robot.ExecuteCommand("F");
            Assert.IsTrue(robot.Position.Location.X == 2 && robot.Position.Location.Y == 0);
        }
    }
}
