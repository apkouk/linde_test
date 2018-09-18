namespace linde_test.Classes.Escenario
{
    public class InitEscenario
    {
        public string InputPath;
        public string Terrain;
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public string Type { get; set; }
        public Position.Position InitialPosition { get; set; }

        public InitEscenario(string path)
        {
            InputPath = path;
            ReadFile();
        }

        private void ReadFile()
        {
         
        }
    }
}