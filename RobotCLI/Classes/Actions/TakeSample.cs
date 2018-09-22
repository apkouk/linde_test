using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Actions
{
    public class TakeSample : IAction
    {
        private Robot Robot;
        public TakeSample(Robot robot)
        {
            Robot = robot;
            Execute();
        }

        public void Execute()
        {
            if (Robot != null)
            {                
                Robot.SamplesCollected.Add(Robot.Map.GetTerrain(Robot.Position.Location));
                Robot.LastState = RobotEnums.States.SampleAdded;
            }
        }

        public void UpdateBattery()
        {
            Robot.Battery = Robot.Battery - 8;            
        }
    }
}