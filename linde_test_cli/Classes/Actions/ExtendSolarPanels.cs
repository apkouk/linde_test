using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Actions
{
    public class ExtendSolarPanels : IAction
    {
        public static int BatteryConsuming = 9;
        private readonly Robot _robot;
        public ExtendSolarPanels(Robot robot)
        {
            _robot = robot;
            Execute();
        }
        public void Execute()
        {
            _robot.LastState = RobotEnums.States.PanelsExtended;
        }

        public void UpdateBattery()
        {
            _robot.Battery += BatteryConsuming;
        }
    }
}