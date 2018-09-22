using linde_test_cli.Classes;
using linde_test_cli.Classes.Escenario;
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
            _robot.Position.Facing = RobotEnums.Facing.West;
            _robot.ExecuteCommand("F");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 0;
            _robot.Position.Location.Y = 2;
            _robot.Position.Facing = RobotEnums.Facing.North;
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
            _robot.Position.Facing = RobotEnums.Facing.South;
            _robot.ExecuteCommand("B");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 0;
            _robot.Position.Location.Y = 1;
            _robot.Position.Facing = RobotEnums.Facing.West;
            _robot.ExecuteCommand("B");
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1);

            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 0;
            _robot.Position.Facing = RobotEnums.Facing.North;
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
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.North);
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.West);
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.South);
            _robot.ExecuteCommand("L");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.East);
        }

        [TestMethod]
        public void ShouldTurnRight()
        {
            LoadRobot();
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.South);
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.West);
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.North);
            _robot.ExecuteCommand("R");
            Assert.IsTrue(_robot.Position.Facing == RobotEnums.Facing.East);
        }

        [TestMethod]
        public void ShouldTakeASample()
        {
            LoadRobot();
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.ExecuteCommand("S");
            Assert.IsTrue(_robot.SamplesCollected[0] == "Si");
            Assert.IsTrue(_robot.Battery == 42);
        }

        private void LoadRobot()
        {
            _robot = new Robot(new Escenario(@"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_run_2.json", @"C:\\Users\\cesco\\Desktop\\Linde NET Test\\test_sol_2_paco.json"));
        }
    }
}

//[TestMethod]
//public void ShouldUseStrategy_ERF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'R', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 0 && _robot.Position.Location.Y == 1 && _robot.Position.Facing == RobotEnums.Facing.West);
//}

//[TestMethod]
//public void ShouldUseStrategy_ELF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'L', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 2 && _robot.Position.Location.Y == 1 && _robot.Position.Facing == RobotEnums.Facing.East);
//}

//[TestMethod]
//public void ShouldUseStrategy_ELLF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'L', 'L', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.North);
//}

//[TestMethod]
//public void ShouldUseStrategy_EBRF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'B', 'R', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.West);
//}

//[TestMethod]
//public void ShouldUseStrategy_EBBLF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'B', 'B', 'L', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 2 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.East);
//}

//[TestMethod]
//public void ShouldUseStrategy_EFF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'F', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1 && _robot.Position.Facing == RobotEnums.Facing.South); 
//}

//[TestMethod]
//public void ShouldUseStrategy_EFLFLF()
//{
//    LoadRobot();
//    _robot.Commands = new[] { 'E', 'F', 'L', 'F', 'L', 'F' };
//    SetInitialPosition(_robot);
//    _robot.ExecuteCommands();
//    Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.North);
//}

//private void SetInitialPosition(Robot robot)
//{
//    _robot.Position.Location.X = 1;
//    _robot.Position.Location.Y = 1;
//    _robot.Position.Facing = RobotEnums.Facing.South;
//}