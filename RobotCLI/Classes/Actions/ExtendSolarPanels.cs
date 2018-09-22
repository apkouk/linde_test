using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Actions
{
    public class ExtendSolarPanels : IAction
    {
        private readonly Robot _robot;
        public ExtendSolarPanels(Robot robot)
        {
            _robot = robot;
            Execute();
        }
        public void Execute()
        {
        }

        public void UpdateBattery()
        {
            _robot.Battery = _robot.Battery + 9;
            _robot.LastState = RobotEnums.States.PanelsExtended; 
        }
    }
}