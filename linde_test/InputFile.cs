using System;


namespace linde_test
{
    public class InputFile
    {
        public string Terrain;
        public int Battery { get; set; }
        public char[] Commands { get; set; }
        public string Type { get; set; }
        public Position InitialPosition { get; set; }

        public InputFile()
        {
        }
    }
}