using System;
using System.Collections;
using linde_test.Classes.Position.Location;

namespace linde_test.Classes.Escenario
{
    public class Robot
    {
        public int Battery { get; set; }
        public Position.Position Position { get; set; }
        public char[] Commands { get; set; }
        public RobotEnums.States LastState { get; set; }
        public Map Map { get; set; }

        public ArrayList VisitedCells = new ArrayList();
        public ArrayList SamplesCollected = new ArrayList();

        public Robot(Position.Position position)
        {
            VisitedCells.Add(NewPosition(position));
            Position = position;
        }

        private Position.Position NewPosition(Position.Position position)
        {
            Location location = new Location
            {
                X = position.Location.X,
                Y = position.Location.Y
            };
            return new Position.Position(location, position.Facing);
        }

        public void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "F":
                    MoveForward();
                    break;
                case "B":
                    MoveBackwards();
                    break;
                case "L":
                    TurnLeft();
                    break;
                case "R":
                    TurnRight();
                    break;
                case "S":
                    TakeSample();
                    break;
                case "E":
                    ExtendSolarPanels();
                    break;
            }
            MoveOnMap();

        }

        private void ExtendSolarPanels()
        {
            Battery = Battery + 9;
            LastState = RobotEnums.States.PanelsExtended;
        }

        private void TakeSample()
        {
            Battery = Battery - 8;
            SamplesCollected.Add(Map.GetTerrain(Position.Location));
            LastState = RobotEnums.States.SampleAdded;
        }

        private void TurnRight()
        {
            switch (Position.Facing)
            {
                case RobotEnums.Facing.East:
                    Position.Facing = RobotEnums.Facing.South;
                    break;
                case RobotEnums.Facing.South:
                    Position.Facing = RobotEnums.Facing.West;
                    break;
                case RobotEnums.Facing.West:
                    Position.Facing = RobotEnums.Facing.North;
                    break;
                case RobotEnums.Facing.North:
                    Position.Facing = RobotEnums.Facing.East;
                    break;
            }
            Battery = Battery - 2;
            LastState = RobotEnums.States.Turned;
        }

        private void TurnLeft()
        {
            switch (Position.Facing)
            {
                case RobotEnums.Facing.East:
                    Position.Facing = RobotEnums.Facing.North;
                    break;
                case RobotEnums.Facing.South:
                    Position.Facing = RobotEnums.Facing.East;
                    break;
                case RobotEnums.Facing.West:
                    Position.Facing = RobotEnums.Facing.South;
                    break;
                case RobotEnums.Facing.North:
                    Position.Facing = RobotEnums.Facing.West;
                    break;
            }
            Battery = Battery - 2;
            LastState = RobotEnums.States.Turned;
        }

        private void MoveBackwards()
        {
            switch (Position.Facing)
            {
                case RobotEnums.Facing.East:
                    Position.Location.X--;
                    break;
                case RobotEnums.Facing.South:
                    Position.Location.Y--;
                    break;
                case RobotEnums.Facing.West:
                    Position.Location.X++;
                    break;
                case RobotEnums.Facing.North:
                    Position.Location.Y++;
                    break;
            }
            Battery = Battery - 3;
            LastState = RobotEnums.States.Moved;
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
            Battery = Battery - 3;
            LastState = RobotEnums.States.Moved;
        }

        private void MoveOnMap()
        {
            if (!Map.IsLocationOnMapBoundaries(Position))
            {
                Position.Location = (Location)(VisitedCells.Count > 0 ? VisitedCells[VisitedCells.Count - 1] : null);
                return;
            }

            if (!Map.IsNewLocationObs(Position) && LastState == RobotEnums.States.Moved)
            {
                Position.Position newPosition = NewPosition(Position);
                if (!IsPositionOnList(newPosition))
                    VisitedCells.Add(newPosition);
            }
            else
            {
                TurnOver();
            }
        }

        private bool IsPositionOnList(Position.Position newPosition)
        {
            foreach (Position.Position visitedCell in VisitedCells)
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


        private void TurnOver()
        {

        }

        public void ExecuteCommands()
        {
            foreach (char command in Commands)
            {
                ExecuteCommand(Convert.ToString(command));
            }
        }
    }
}