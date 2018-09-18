namespace linde_test.Classes.Escenario
{
    public class OutputFile
    {
        public string OutPutPath;
        public string[] VisitedCells { get; set; }
        public string[] SamplesCollected { get; set; }
        public int Battery { get; set; }
        public Position.Position FinalPosition;

        public OutputFile()
        {
        }
    }
}