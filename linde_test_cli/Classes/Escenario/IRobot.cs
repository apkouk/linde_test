namespace linde_test.Classes.Escenario
{
    public interface IRobot
    {
        int Battery { get; set; }
        char[] Commands { get; set; }
        Map Map { get; set; }
        Escenario Escenario { get; set; }
        Position.Position Position { get; set; }
        RobotEnums.States LastState { get; set; }
        void ExecuteCommand(string command);
        void ExecuteCommands();
    }
}