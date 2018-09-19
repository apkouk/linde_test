using System.Collections;
using linde_test.Classes.Position.Location;

namespace linde_test.Classes.Escenario
{
    public class Robot
    {
        public int Battery { get; set; }
        public Position.Position Position { get; set; }
        public char[] Commands { get; set; }
        public Map Map { get; set; }
        protected ArrayList _visitedCells = new ArrayList();

        public Robot(Position.Position position)
        {
            _visitedCells.Add(NewPosition(position));
            Position = position;
        }

        private object NewPosition(Position.Position position)
        {
            Location location = new Location();
            location.X = position.Location.X;
            location.Y = position.Location.Y;
            return new Position.Position(location, position.Facing);
        }

        public void ExecuteCommands()
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "F":
                    MoveForward();
                    break;
            }
        }

        private void MoveForward()
        {
            switch (Position.Facing)
            {
                case RobotEnums.Facing.East:
                    Position.Location.X++;
                    break;
                case RobotEnums.Facing.South:
                    Position.Location.Y++;
                    break;
                case RobotEnums.Facing.West:
                    Position.Location.X--;
                    break;
                case RobotEnums.Facing.North:
                    Position.Location.Y--;
                    break;
            }
            MoveOnMap();
        }

        private void MoveOnMap()
        {
            if (IsOnMapBoundaries() && !IsNewLocationObs())
            {
                _visitedCells.Add(NewPosition(Position));
            }
            else
            {
                StartTurning();
            }
        }

        private bool IsNewLocationObs()
        {
            return GetTerrain(Position.Location).Equals("Obs");
        }

        private string GetTerrain(Location location)
        {
            string[] yVal = Map.Terrain[location.Y];
            return yVal[location.X];
        }

        private void StartTurning()
        {
            throw new System.NotImplementedException();
        }

        private bool IsOnMapBoundaries()
        {
            return Position.Location.X <= Map.Terrain[0].Length - 1 && Position.Location.Y <= Map.Terrain.Length - 1;
        }
    }
}