using System.Collections;
using Newtonsoft.Json;
using System.IO;
using linde_test.Classes.JsonObjects;

namespace linde_test.Classes.Escenario
{
    public class Escenario
    {
        public EscenarioJson Properties;
        public string OutputPath { get; }

        public ArrayList Terrain { get; set; }
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public Position.Position InitialPosition { get; set; }

        public Escenario(string path, string outputPath)
        {
            OutputPath = outputPath;
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

                Terrain = Properties.Terrain;
                Battery = Properties.Battery;
                Commands = Properties.Commands;
                InitialPosition = Properties.InitialPosition;
            }
        }
    }
}
