using System;
using System.Collections.Generic;
using System.IO;
using linde_test_cli.Classes.Actions;
using linde_test_cli.Classes.JsonObjects;
using linde_test_cli.Classes.Movements;
using linde_test_cli.Interfaces;
using Newtonsoft.Json;

namespace linde_test_cli.Classes.Escenario
{
    public class Robot : IRobot
    {
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public Map Map { get; set; }
        public Escenario Escenario { get; set; }
        public Position.Position Position { get; set; }
        public RobotEnums.States LastState { get; set; }

        public Position.Position LastPosition => VisitedCells[VisitedCells.Count - 1];
        public List<Position.Position> VisitedCells = new List<Position.Position>();
        public readonly List<string> SamplesCollected = new List<string>();

        public Robot(Escenario escenario)
        {
            Escenario = escenario;
            Map = new Map(Escenario.Terrain);
            Battery = Escenario.Battery;
            Commands = Escenario.Commands;
            Position = Escenario.InitialPosition;
            VisitedCells.Add(Map.NewPosition(Position));
        }

        public void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "F":
                    new MoveForward(this).UpdateBattery();
                    break;
                case "B":
                    new MoveBackwards(this).UpdateBattery();
                    break;
                case "L":
                    new TurnLeft(this).UpdateBattery();
                    break;
                case "R":
                    new TurnRight(this).UpdateBattery();
                    break;
                case "S":
                    new TakeSample(this).UpdateBattery();
                    break;
                case "E":
                    new ExtendSolarPanels(this).UpdateBattery();
                    break;
            }
        }

        public void MoveOnMap()
        {
            if (LastState == RobotEnums.States.Turned)
                return;

            if (!Map.IsLocationOnMapBoundaries(Position))
            {
                Position = LastPosition;
                return;
            }

            if (Map.IsNewLocationObs(Position))
            {
                Position = Map.FindBackoff(this);
            }

            if (LastState == RobotEnums.States.Moved)
                Map.AddNewVisitedCell(this);
        }

        public void ExecuteCommands()
        {
            foreach (char command in Commands)
            {
                ExecuteCommand(Convert.ToString(command));
                MoveOnMap();
            }
           
        }

        public void WriteOutput()
        {
            using (StreamWriter file = File.CreateText(Escenario.OutputPath))
            {
                OutputFileJson output = new OutputFileJson
                {
                    VisitedCells = ConvertToJsonObjects(VisitedCells),
                    SamplesCollected = SamplesCollected.ToArray(),
                    Battery = Battery,
                    FinalPosition = new PositionJson(Position.Location, Position.Facing)
                };

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, output);
            }
        }

        private List<object> ConvertToJsonObjects(List<Position.Position> visitedCells)
        {
            List<object> list = new List<object>();
            foreach (Position.Position visitedCell in visitedCells)
            {
                var cell = new { visitedCell.Location.X, visitedCell.Location.Y };
                list.Add(cell);
            }
            return list;
        }
    }
}