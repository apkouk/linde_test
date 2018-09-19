namespace linde_test.Classes.Escenario
{
    public class Robot
    {
        public int Battery { get; set; }
        public Position.Position InitialPosition { get; set; }
        public char[] Commands { get; set; }
        public Map Map { get; set; }

        public void ExecuteCommands()
        {
            throw new System.NotImplementedException();
        }
    }
}