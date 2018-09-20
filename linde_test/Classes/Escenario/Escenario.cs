using System;
using linde_test.Classes.Position.Location;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace linde_test.Classes.Escenario
{
    public class Escenario
    {
        public EscenarioJson Properties;

        private string _outputPath;
        public string OutputPath
        {
            get { return _outputPath; }
            set { _outputPath = value; }
        }


        public Escenario(string path, string outputPath)
        {
            _outputPath = outputPath;
            ReadFile(path);
        }

        private void ReadFile(string path)
        {
            if (path.EndsWith(".json"))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    Properties = JsonConvert.DeserializeObject<EscenarioJson>(json);
                }
            }
        }

        public class EscenarioJson
        {
            public ArrayList Terrain;
            public int Battery { get; set; }
            public char[] Commands { get; set; }
            public Position.Position InitialPosition { get; set; }
        }

        public class OutputFileJson
        {
            [JsonProperty(Order = 1)]
            public List<object> VisitedCells { get; set; }
            [JsonProperty(Order = 2)]
            public object[] SamplesCollected { get; set; }
            [JsonProperty(Order = 3)]
            public int Battery { get; set; }
            [JsonProperty(Order = 4)]
            public PositionJson FinalPosition;
        }

        public class PositionJson
        {
            public Location Location;
            public string Facing;
            
            public PositionJson(Location location, RobotEnums.Facing facing)
            {
                Location = location;
                Facing = Enum.GetName(typeof(RobotEnums.Facing), facing);
            }
        }
    }
}
