using linde_test.Interfaces;
using linde_test.Classes.Escenario;

namespace linde_test.Classes.Movements
{
    public class MoveBackwards : IMovement
    {
        public void Move(Robot robot)
        {
            switch (robot.Position.Facing)
            {
                case RobotEnums.Facing.East:
                    robot.Position.Location.X--;
                    break;
                case RobotEnums.Facing.South:
                    robot.Position.Location.Y--;
                    break;
                case RobotEnums.Facing.West:
                    robot.Position.Location.X++;
                    break;
                case RobotEnums.Facing.North:
                    robot.Position.Location.Y++;
                    break;
            }
            robot.Battery = robot.Battery - 3;
            robot.LastState = RobotEnums.States.Moved;
        }

    }
}