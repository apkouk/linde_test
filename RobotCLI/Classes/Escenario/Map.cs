using System.Collections;
using System.Collections.Generic;
using linde_test_cli.Classes.Position.Location;

namespace linde_test_cli.Classes.Escenario
{
    public class Map
    {
        private string[][] _terrain;

        public Map(ArrayList terrain)
        {
            LoadTerrain(terrain);
        }

        private void LoadTerrain(ArrayList propertiesTerrain)
        {
            _terrain = new string[propertiesTerrain.Count][];

            int count = 0;
            foreach (Newtonsoft.Json.Linq.JArray array in propertiesTerrain)
            {
                string[] defArray = new string[array.Count];
                for (int i = 0; i < array.Count; i++)
                {
                    defArray[i] = array.Root[i].ToString();
                }
                _terrain[count] = defArray;
                count++;
            }
        }

        public bool IsNewLocationObs(Position.Position position)
        {
            if (IsLocationOnMapBoundaries(position))
                return GetTerrain(position.Location).Equals("Obs");
            return false;
        }

        public string GetTerrain(Location location)
        {
            string[] yVal = _terrain[location.Y];
            return yVal[location.X];
        }

        public bool IsLocationOnMapBoundaries(Position.Position position)
        {
            return position.Location.X <= _terrain[0].Length - 1 && position.Location.Y <= _terrain.Length - 1;
        }

        public void MoveOnMap(Robot robot)
        {
            if (robot.LastState == RobotEnums.States.Turned)
                return;

            if (!IsLocationOnMapBoundaries(robot.Position))
            {
                robot.Position = robot.LastPosition;
                return;
            }

            if (IsNewLocationObs(robot.Position))
            {
                robot.Position = FindBackoff(robot);
            }

            if (robot.LastState == RobotEnums.States.Moved)
                AddNewVisitedCell(robot);
        }

        private void AddNewVisitedCell(Robot robot)
        {
            Position.Position newPosition = NewPosition(robot.Position);
            if (!IsPositionOnList(newPosition, robot.VisitedCells))
                robot.VisitedCells.Add(newPosition);
        }

        private Position.Position FindBackoff(Robot robot)
        {
            Robot explorer = new RobotExplorer(robot, robot.Escenario);
            return explorer.Position;

            //Position.Position lastPosition = NewPosition(robot.Position);
            //Robot explorer = new RobotExplorer(robot.Escenario);
            //explorer.Battery = robot.Battery;
            //explorer.LastState = robot.LastState;
            //explorer.VisitedCells = robot.VisitedCells;

            //while (lastPosition != explorer.Position && !IsLocationOnMapBoundaries(explorer.Position) || IsNewLocationObs(explorer.Position))
            //{
            //    explorer.ExecuteCommands();
            //}

            //robot.Battery = explorer.Battery;
            //robot.LastState = explorer.LastState;
            //robot.VisitedCells = explorer.VisitedCells;
            //return explorer.Position;
        }

        private bool IsPositionOnList(Position.Position newPosition, List<Position.Position> visitedCells)
        {
            foreach (Position.Position visitedCell in visitedCells)
            {
                if (visitedCell.Location.X.Equals(newPosition.Location.X) && visitedCell.Location.Y.Equals(newPosition.Location.Y))
                {
                    return true;
                }
            }
            return false;
        }

        public Position.Position NewPosition(Position.Position position)
        {
            Location location = new Location
            {
                X = position.Location.X,
                Y = position.Location.Y
            };
            return new Position.Position(location, position.Facing);
        }
    }
}