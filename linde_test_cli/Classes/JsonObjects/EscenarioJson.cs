using System.Collections;

namespace linde_test_cli.Classes.JsonObjects
{
    public class EscenarioJson
    {
        public ArrayList Terrain;
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public Position.Position InitialPosition { get; set; }
    }
}