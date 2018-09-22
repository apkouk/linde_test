using System.Collections.Generic;

namespace linde_test_cli.Classes.Escenario
{
    public sealed class RobotExplorer : Robot
    {
        public Robot Robot;
        public List<char[]> Strategies { get; set; }
        public RobotExplorer(Robot robot, Escenario escenario) : base(escenario)
        {
            Robot = robot;
            List<char[]> strategies = new List<char[]>
            {
                new[] {'E', 'R', 'F'},
                new[] {'E', 'L', 'F'},
                new[] {'E', 'L', 'L', 'F'},
                new[] {'E', 'B', 'R', 'F'},
                new[] {'E', 'B', 'B', 'L', 'F'},
                new[] {'E', 'F', 'F'},
                new[] {'E', 'F', 'L', 'F', 'L', 'F'}
            };
            Strategies = strategies;
        }

        public void ExecuteStrategies()
        {
            Position.Position initialPosition = Map.NewPosition(Robot.LastPosition);
            VisitedCells.Add(Map.NewPosition(Robot.LastPosition));
            Position = Robot.LastPosition;
            Battery = Robot.Battery;

            foreach (char[] strategy in Strategies)
            {
                Position = Map.NewPosition(initialPosition);
                foreach (char command in strategy)
                {
                    ExecuteCommand(command.ToString());
                    if (Robot.Map.IsNewLocationObs(Position))
                        ExecuteCommand("B");
                }

                if (Robot.Map.IsLocationOnMapBoundaries(Position) && !Robot.Map.IsNewLocationObs(Position) && Position != initialPosition)
                {
                    Robot.Battery = Battery;
                    Robot.Position = Position;
                    Robot.MoveOnMap();
                    break;
                }
            }
        }
    }
}
