using linde_test.Classes.Position.Location;
using System.Collections;
using System.Collections.Generic;

namespace linde_test.Classes.Escenario
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

        private bool IsNewLocationObs(Position.Position position)
        {
            return GetTerrain(position.Location).Equals("Obs");
        }

        public string GetTerrain(Location location)
        {
            string[] yVal = _terrain[location.Y];
            return yVal[location.X];
        }

        private bool IsLocationOnMapBoundaries(Position.Position position)
        {
            return position.Location.X <= _terrain[0].Length - 1 && position.Location.Y <= _terrain.Length - 1;
        }

        public void MoveOnMap(Robot robot)
        {
            if (robot.LastState == RobotEnums.States.Turned)
                return;

            if (!IsLocationOnMapBoundaries(robot.Position) || IsNewLocationObs(robot.Position))
            {
                robot.Position = NewPosition(robot.VisitedCells.Count > 0 ? robot.VisitedCells[robot.VisitedCells.Count - 1] : null);
                robot.ExecuteCommand("R");
                robot.ExecuteCommand("F");
                return;
            }

            if (robot.LastState == RobotEnums.States.Moved)
            {
                Position.Position newPosition = NewPosition(robot.Position);
                if (!IsPositionOnList(newPosition, robot.VisitedCells))
                    robot.VisitedCells.Add(newPosition);
            }
        }

        private bool IsPositionOnList(Position.Position newPosition, List<Position.Position> visitedCells)
        {
            foreach (Position.Position visitedCell in visitedCells)
            {
                if (visitedCell.Facing.Equals(newPosition.Facing)
                    && visitedCell.Location.X.Equals(newPosition.Location.X)
                    && visitedCell.Location.Y.Equals(newPosition.Location.Y))
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