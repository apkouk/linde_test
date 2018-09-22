using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Actions
{
    public class ExtendSolarPanels : IAction
    {
        private Robot Robot;
        public ExtendSolarPanels(Robot robot)
        {
            Robot = robot;
            Execute();
        }
        public void Execute()
        {
        }

        public void UpdateBattery()
        {
            Robot.Battery = Robot.Battery + 9;
            Robot.LastState = RobotEnums.States.PanelsExtended; 
        }
    }
}