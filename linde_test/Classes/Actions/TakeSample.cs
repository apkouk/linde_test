using linde_test.Interfaces;
using linde_test.Classes.Escenario;

namespace linde_test.Classes.Actions
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
                Robot.Battery = Robot.Battery - 8;
                Robot.SamplesCollected.Add(Robot.Map.GetTerrain(Robot.Position.Location));
                Robot.LastState = RobotEnums.States.SampleAdded;
            }
        }
    }
}