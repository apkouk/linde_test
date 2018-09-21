using System.Collections;
using Newtonsoft.Json;
using System.IO;
using linde_test.Classes.JsonObjects;

namespace linde_test.Classes.Escenario
{
    public class Escenario
    {
        private EscenarioJson _properties;
        public string OutputPath { get; }

        public ArrayList Terrain { get; set; }
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public Position.Position InitialPosition { get; set; }

        public Escenario(string path, string outputPath)
        {
            OutputPath = outputPath;
            LoadEscenario(path);
        }

        private void LoadEscenario(string path)
        {
            if (path.EndsWith(".json"))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    _properties = JsonConvert.DeserializeObject<EscenarioJson>(json);
                }

                Terrain = _properties.Terrain;
                Battery = _properties.Battery;
                Commands = _properties.Commands;
                InitialPosition = _properties.InitialPosition;
            }
        }
    }
}
