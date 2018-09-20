using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace linde_test.Classes.Escenario
{
    public class Robot
    {
        public int Battery { get; set; }
        private char[] Commands { get; set; }
        private Map Map { get; set; }
        public Escenario Escenario { get; set; }
        public Position.Position Position { get; set; }
        public RobotEnums.States LastState { get; set; }
        public readonly List<Position.Position> VisitedCells = new List<Position.Position>();
        public readonly ArrayList SamplesCollected = new ArrayList();


        public Robot(Escenario escenario)
        {
            Escenario = escenario;
            Map = new Map(Escenario.Properties.Terrain);
            Battery = Escenario.Properties.Battery;
            Commands = Escenario.Properties.Commands;
            Position = Escenario.Properties.InitialPosition;
            VisitedCells.Add(Map.NewPosition(Position));
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

        public void ExecuteCommands()
        {
            foreach (char command in Commands)
            {
                ExecuteCommand(Convert.ToString(command));
            }
            WriteOutput();
        }

        private void WriteOutput()
        {
            using (StreamWriter file = File.CreateText(Escenario.OutputPath))
            {
                Escenario.OutputFileJson output = new Escenario.OutputFileJson();
                output.VisitedCells = ConvertToJsonObjects(VisitedCells);
                output.SamplesCollected = (string[])SamplesCollected.ToArray(typeof(string));
                output.Battery = Battery;
                output.FinalPosition = new Escenario.PositionJson(Position.Location, Position.Facing);

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, output);
            }
        }

        private List<object> ConvertToJsonObjects(List<Position.Position> visitedCells)
        {
            List<object> list = new List<object>();
            foreach (Position.Position visitedCell in visitedCells)
            {
                var foo = new {X = visitedCell.Location.X, Y = visitedCell.Location.Y};
                list.Add(foo);
            }
            return list;
        }
    }
}