using Newtonsoft.Json;
using System.IO;
using linde_test.Classes.JsonObjects;

namespace linde_test.Classes.Escenario
{
    public partial class Escenario
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
    }
}
