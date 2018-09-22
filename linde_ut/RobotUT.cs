using System.Collections.Generic;
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

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_ERF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'R', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 0 && _robot.Position.Location.Y == 1 && _robot.Position.Facing == RobotEnums.Facing.West);
        }

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_ELF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'L', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1 && _robot.Position.Facing == RobotEnums.Facing.East);
        }

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_ELLF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'L', 'L', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.North);
        }

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_EBRF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'B', 'R', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 0 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.West);
        }

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_EBBLF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
               new[] {'E', 'B', 'B', 'L', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 2 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.East);
        }

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_EFF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'F', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 1 && _robot.Position.Facing == RobotEnums.Facing.South);
        }

        [TestCategory("BackoffStrategies")]
        [TestMethod]
        public void Strategy_EFLFLF()
        {
            LoadRobot();
            SetInitialPosition(_robot);
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'F', 'L', 'F', 'L', 'F'}
            };

            RobotExplorer explorer = new RobotExplorer(_robot, _robot.Escenario)
            {
                Strategies = strategies
            };
            explorer.ExecuteStrategies();
            Assert.IsTrue(_robot.Position.Location.X == 1 && _robot.Position.Location.Y == 0 && _robot.Position.Facing == RobotEnums.Facing.North);
        }

        private void SetInitialPosition(Robot robot)
        {
            _robot.Position.Location.X = 1;
            _robot.Position.Location.Y = 1;
            _robot.Position.Facing = RobotEnums.Facing.South;

            _robot.LastPosition.Location.X = 1;
            _robot.LastPosition.Location.Y = 1;
            _robot.LastPosition.Facing = RobotEnums.Facing.South;
        }

        [TestCategory("LindeCLI")]
        [TestMethod]
        public void ShouldWriteOutput()
        {
            LoadRobot();
            _robot.WriteOutput();
            Assert.IsTrue(File.Exists(_robot.Escenario.OutputPath));
        }

        [TestCategory("LindeCLI")]
        [TestMethod]
        public void ShouldExtendSolarPanels()
        {
            LoadRobot();
            _robot.ExecuteCommand("E");
            Assert.IsTrue(_robot.Battery == 59);
        }

        [TestCategory("LindeCLI")]
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

        [TestCategory("LindeCLI")]
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

        [TestCategory("LindeCLI")]
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

        [TestCategory("LindeCLI")]
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

        [TestCategory("LindeCLI")]
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
