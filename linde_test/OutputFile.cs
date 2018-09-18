using System;


namespace linde_test
{
    public class OutputFile
    {
        public string[] VisitedCells { get; set; }
        public string[] SamplesCollected { get; set; }
        public int Battery { get; set; }
        public Position FinalPosition;

        public OutputFile()
        {
        }
    }
}