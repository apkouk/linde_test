using Newtonsoft.Json;
using System.Collections;
using System.IO;

namespace linde_test.Classes.Escenario
{
    public class Escenario
    {
        public EscenarioJsonObj Properties;

        public Escenario(string path)
        {
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
    }
}
