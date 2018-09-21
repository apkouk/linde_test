using linde_test.Classes.Movements;

namespace linde_test.Classes.Escenario
{
    public class RobotExplorer : Robot
    {
        public RobotExplorer(Escenario escenario) : base(escenario)
        {
            char[] commands = new char[3];
            commands[0] = 'B';
            commands[1] = 'R';
            commands[2] = 'F';
            Commands = commands;
        }

        public override void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "F":
                    new MoveForward(this);
                    break;
                case "B":
                    new MoveBackwards(this);
                    break;
                case "R":
                    new TurnRight(this).UpdateBattery();
                    break;
            }
            Map.MoveOnMap(this);
        }
    }
}
