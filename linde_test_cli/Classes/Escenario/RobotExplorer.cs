using System.Collections.Generic;

namespace linde_test_cli.Classes.Escenario
{
    public sealed class RobotExplorer : Robot
    {
        private readonly Robot _robot;
        public List<char[]> Strategies { private get; set; }

        public RobotExplorer(Robot robot, Escenario escenario) : base(escenario)
        {
            _robot = robot;
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
            Position.Position initialPosition = Map.NewPosition(_robot.LastPosition);
            VisitedCells.Add(Map.NewPosition(_robot.LastPosition));
            Position = _robot.LastPosition;
            Battery = _robot.Battery;

            foreach (char[] strategy in Strategies)
            {
                Position = Map.NewPosition(initialPosition);
                foreach (char command in strategy)
                {
                    ExecuteCommand(command.ToString());
                    if (_robot.Map.IsNewLocationObs(Position))
                        ExecuteCommand("B");
                }

                if (_robot.Map.IsLocationOnMapBoundaries(Position) && !_robot.Map.IsNewLocationObs(Position) && Position != initialPosition)
                {
                    _robot.Battery = Battery;
                    _robot.Position = Position;
                    _robot.MoveOnMap();
                    break;
                }
            }
        }
    }
}
