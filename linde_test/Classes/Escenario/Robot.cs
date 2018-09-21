using linde_test.Classes.Actions;
using linde_test.Classes.JsonObjects;
using linde_test.Classes.Movements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using linde_test.Interfaces;

namespace linde_test.Classes.Escenario
{
    public class Robot
    {
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public Map Map { get; set; }
        public Escenario Escenario { get; set; }
        public Position.Position Position { get; set; }
        public RobotEnums.States LastState { get; set; }

        private Position.Position lastPosition;
        public Position.Position LastPosition
        {
            get { return VisitedCells[VisitedCells.Count - 1]; }
            set { lastPosition = value; }
        }

        public List<Position.Position> VisitedCells = new List<Position.Position>();
        public List<string> ExecutedCommands = new List<string>();
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

        public virtual void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "F":
                    new MoveForward(this).UpdateBattery();
                    ExecutedCommands.Add("(F) MoveForward");
                    break;
                case "B":
                    new MoveBackwards(this).UpdateBattery();
                    ExecutedCommands.Add("(B) MoveBackwards");
                    break;
                case "L":
                    new TurnLeft(this).UpdateBattery();
                    ExecutedCommands.Add("(L) TurnLeft");
                    break;
                case "R":
                    new TurnRight(this).UpdateBattery();
                    ExecutedCommands.Add("(R) TurnRight");
                    break;
                case "S":
                    new TakeSample(this).UpdateBattery();
                    ExecutedCommands.Add("(S) TakeSample");
                    break;
                case "E":
                    new ExtendSolarPanels(this).UpdateBattery();
                    ExecutedCommands.Add("(E) ExtendSolarPanels");
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