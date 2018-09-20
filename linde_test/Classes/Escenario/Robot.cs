using linde_test.Classes.JsonObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using linde_test.Classes.Actions;
using linde_test.Classes.Movements;
using linde_test.Interfaces;

namespace linde_test.Classes.Escenario
{
    public class Robot
    {
        public int Battery { get; set; }
        private char[] Commands { get; set; }
        public Map Map { get; set; }
        public Escenario Escenario { get; set; }
        public Position.Position Position { get; set; }
        public RobotEnums.States LastState { get; set; }
        public readonly List<Position.Position> VisitedCells = new List<Position.Position>();
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
            IMovement movement;
            IAction action;
            switch (command)
            {
                case "F":
                    movement = new MoveForward();
                    movement.Move(this);
                    break;
                case "B":
                    movement = new MoveBackwards();
                    movement.Move(this);
                    break;
                case "L":
                    movement = new TurnLeft();
                    movement.Move(this);
                    break;
                case "R":
                    movement = new TurnRight();
                    movement.Move(this);
                    break;
                case "S":
                    action = new TakeSample();
                    action.Execute(this);
                    break;
                case "E":
                    action = new ExtendSolarPanels();
                    action.Execute(this);
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
                OutputFileJson output = new OutputFileJson
                {
                    VisitedCells = ConvertToJsonObjects(VisitedCells),
                    SamplesCollected =  SamplesCollected.ToArray(),
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
                var cell = new {visitedCell.Location.X, visitedCell.Location.Y};
                list.Add(cell);
            }
            return list;
        }
    }
}