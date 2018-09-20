using System.Collections;

namespace linde_test.Classes.JsonObjects
{
    public class EscenarioJson
    {
        public ArrayList Terrain;
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public Position.Position InitialPosition { get; set; }
    }
}