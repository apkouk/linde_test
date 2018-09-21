using System.Collections.Generic;
using linde_test.Classes.Actions;
using linde_test.Classes.Movements;

namespace linde_test.Classes.Escenario
{
    public sealed class RobotExplorer : Robot
    {
     
        public RobotExplorer(Robot robot, Escenario escenario) : base(escenario)
        {
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

            Position.Position initialPosition = Map.NewPosition(robot.LastPosition);
            VisitedCells.Add(Map.NewPosition(robot.LastPosition));
            Position = robot.LastPosition;
            Battery = robot.Battery;
          
            foreach (char[] strategy in strategies)
            {
                foreach (char command in strategy)
                {
                    ExecuteCommand(command.ToString());
                }

                if(robot.Map.IsLocationOnMapBoundaries(Position) && !robot.Map.IsNewLocationObs(Position))
                {
                    robot.Battery = Battery;
                    robot.Position = Position;
                    robot.VisitedCells.Insert(robot.VisitedCells.IndexOf(Position), initialPosition);
                    Map.MoveOnMap(robot);
                    break;
                }
            }
        }
    }
}
