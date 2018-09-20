using linde_test.Classes.Escenario;
using linde_test.Interfaces;

namespace linde_test.Classes.Actions
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
            if (Robot != null)
            {
                Robot.Battery = Robot.Battery + 9;
                Robot.LastState = RobotEnums.States.PanelsExtended;
            }
        }
    }
}