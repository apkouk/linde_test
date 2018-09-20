using linde_test.Interfaces;
using linde_test.Classes.Escenario;

namespace linde_test.Classes.Actions
{ 
    public class TakeSample : IAction
    {
        public void Execute(Robot robot)
        {
            robot.Battery = robot.Battery - 8;
            robot.SamplesCollected.Add(robot.Map.GetTerrain(robot.Position.Location));
            robot.LastState = RobotEnums.States.SampleAdded;
        }
    }
}