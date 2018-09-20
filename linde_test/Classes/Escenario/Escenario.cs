using System;
using linde_test.Classes.Position.Location;
using Newtonsoft.Json;
using System.Collections;
using System.IO;

namespace linde_test.Classes.Escenario
{
    public class Escenario
    {
        public EscenarioJsonObj Properties;

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
                    Properties = JsonConvert.DeserializeObject<EscenarioJsonObj>(json);
                }
            }
        }

        public class EscenarioJsonObj
        {
            public ArrayList Terrain;
            public int Battery { get; set; }
            public char[] Commands { get; set; }
            public Position.Position InitialPosition { get; set; }
        }

        public class OutputFile
        {
            public string[] VisitedCells { get; set; }
            public string[] SamplesCollected { get; set; }
            public int Battery { get; set; }
            public PositionObj FinalPosition;
        }

        public class PositionObj
        {
            public Location Location;
            public string Facing;
            
            public PositionObj(Location location, RobotEnums.Facing facing)
            {
                Location = location;
                Facing = Enum.GetName(typeof(RobotEnums.Facing), facing);
            }
        }
    }
}
