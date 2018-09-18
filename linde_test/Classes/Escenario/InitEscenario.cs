using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace linde_test.Classes.Escenario
{
    public class InitEscenario
    {
        private readonly string _inputPath;
        public InitEscenario(string path)
        {
            _inputPath = path;
            ReadFile();
        }

        private void ReadFile()
        {
            using (StreamReader r = new StreamReader(_inputPath))
            {
                string json = r.ReadToEnd();
                Escenario escenario = JsonConvert.DeserializeObject<Escenario>(json);
            }
        }

        private class Escenario
        {
            public ArrayList Terrain;
            public int Battery { get; set; }
            public char[] Commands { get; set; }
            public Position.Position InitialPosition { get; set; }
        }
    }
}
