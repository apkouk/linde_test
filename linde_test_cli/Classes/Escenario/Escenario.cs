using System.Collections;
using System.IO;
using linde_test_cli.Classes.JsonObjects;
using Newtonsoft.Json;

namespace linde_test_cli.Classes.Escenario
{
    public class Escenario
    {
        public string OutputPath { get; }
        public ArrayList Terrain { get; private set; }
        public int Battery { get; private set; }
        public char[] Commands { get; private set; }
        public Position.Position InitialPosition { get; private set; }

        public Escenario(string path, string outputPath)
        {
            OutputPath = outputPath;
            LoadEscenario(path);
        }

        private void LoadEscenario(string path)
        {
            if (!path.EndsWith(".json")) return;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Terrain = JsonConvert.DeserializeObject<EscenarioJson>(json).Terrain;
                Battery = JsonConvert.DeserializeObject<EscenarioJson>(json).Battery;
                Commands = JsonConvert.DeserializeObject<EscenarioJson>(json).Commands;
                InitialPosition = JsonConvert.DeserializeObject<EscenarioJson>(json).InitialPosition; 
            }
        }
    }
}
