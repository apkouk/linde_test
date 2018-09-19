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
        
        public Robot(Escenario escenario)
        {
            Map = new Map(escenario.Properties.Terrain);
            Battery = escenario.Properties.Battery;
            Commands = escenario.Properties.Commands;
            VisitedCells.Add(Map.NewPosition(escenario.Properties.InitialPosition));
            Position = escenario.Properties.InitialPosition;
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
            Map.MoveOnMap(this);
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
        
        public void ExecuteCommands()
        {
            foreach (char command in Commands)
            {
                ExecuteCommand(Convert.ToString(command));
            }
        }
    }
}