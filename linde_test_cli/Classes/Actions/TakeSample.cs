using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Actions
{
    public class TakeSample : IAction
    {
        public static int BatteryConsuming = 8;
        private readonly Robot _robot;
        public TakeSample(Robot robot)
        {
            _robot = robot;
            Execute();
        }

        public void Execute()
        {
            if (_robot != null)
            {                
                _robot.SamplesCollected.Add(_robot.Map.GetTerrain(_robot.Position.Location));
                _robot.LastState = RobotEnums.States.SampleAdded;
            }
        }

        public void UpdateBattery()
        {
            _robot.Battery -= BatteryConsuming;            
        }
    }
}