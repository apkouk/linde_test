using linde_test.Classes.Escenario;
using linde_test.Interfaces;

namespace linde_test.Classes.Actions
{
    public class ExtendSolarPanels : IAction
    {
        public void Execute(Robot robot)
        {
            robot.Battery = robot.Battery + 9;
            robot.LastState = RobotEnums.States.PanelsExtended;
        }
    }
}