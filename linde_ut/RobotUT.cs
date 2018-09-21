using linde_test.Classes.Escenario;
using linde_test.Classes.Position;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace linde_ut
{
    [TestClass]
    public class RobotUt
    {
        private Robot _robot;

        [TestMethod]
        public void ShouldWriteOutput()
        {
            LoadRobot();
            Assert.IsTrue(File.Exists(_robot.Escenario.OutputPath));
        }

        //    [TestMethod]
        //public void ShouldTurnOverFacing()
        //{
        //    LoadRobot();
        //    linde_test.Classes.Position.Location.Location newLocArray = new linde_test.Classes.Position.Location.Location
        //    {
        //        X = 1,
        //        Y = 2
        //    };
        //    Position newPos = new Position(newLocArray, linde_test.RobotEnums.Facing.South);
        //    _robot.VisitedCells.Add(newPos);

        //    linde_test.Classes.Position.Location.Location newLocObj = new linde_test.Classes.Position.Location.Location
        //    {
        //        X = 1,
        //        Y = 2
        //    };
        //    Position newPosObj = new Position(newLocObj, linde_test.RobotEnums.Facing.South);
        //    _robot.Position = newPosObj;

        //    _robot.ExecuteCommand("F");
        //    Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.West);
        //}

        [TestMethod]
        public void ShouldExtendSolarPanels()
        {
            LoadRobot();
            _robot.ExecuteCommand("E");
            Assert.IsTrue(_robot.Battery == 59);
        }

        [TestMethod]
        public void ShouldMoveOneForward()
        {
            LoadRobot();
            _robot.ExecuteCommand("F");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 0);

            _robot.Position.Location.X = 2;
            _robot.Position.Location.Y = 1;
            _robot.Position.Facing = linde_test.RobotEnums.Facing.West;
            _robot.ExecuteCommand("F");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 0;
            _robot.Position.Location.Y = 2;
            _robot.Position.Facing = linde_test.RobotEnums.Facing.North;
            _robot.ExecuteCommand("F");
            Assert.IsTrue(_robot.Position.Location.X == 0 && _robot.Position.Location.Y == 1);
        }

        [TestMethod]
        public void ShouldMoveOneBackwards()
        {
            LoadRobot();
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.ExecuteCommand("B");
            Assert.IsTrue(_robot.Position.Location.X == 0 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 2;
            _robot.Position.Facing = linde_test.RobotEnums.Facing.South;
            _robot.ExecuteCommand("B");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 0;
            _robot.Position.Location.Y = 1;
            _robot.Position.Facing = linde_test.RobotEnums.Facing.West;
            _robot.ExecuteCommand("B");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 0;
            _robot.Position.Facing = linde_test.RobotEnums.Facing.North;
            _robot.ExecuteCommand("B");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);
        }

        [TestMethod]
        public void ShouldTurnLeft()
        {
            LoadRobot();
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.North);
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.West);
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.South);
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.East);
        }

        [TestMethod]
        public void ShouldTurnRight()
        {
            LoadRobot();
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.South);
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.West);
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.North);
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == linde_test.RobotEnums.Facing.East);
        }

        [TestMethod]
        public void ShouldTakeASample()
        {
            LoadRobot();
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.ExecuteCommand("S");
            Assert.IsTrue((string)_robot.SamplesCollected[0] == "Si");
            Assert.IsTrue(_robot.Battery == 42);
        }

        private void LoadRobot()
        {
            _robot = new Robot(new Escenario(@"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_run_1.json", @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_sol_1_paco.json"));
        }
    }
}
