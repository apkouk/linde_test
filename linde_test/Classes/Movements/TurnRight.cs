using linde_test.Classes.Escenario;
using linde_test.Interfaces;

namespace linde_test.Classes.Movements
{
    public class TurnRight : IMovement
    {
        private Robot Robot;
        public TurnRight(Robot robot)
        {
            Robot = robot;
            Move();
        }

        public void Move()
        {
            if (Robot != null)
            {
                switch (Robot.Position.Facing)
                {
                    case RobotEnums.Facing.East:
                        Robot.Position.Facing = RobotEnums.Facing.South;
                        break;
                    case RobotEnums.Facing.South:
                        Robot.Position.Facing = RobotEnums.Facing.West;
                        break;
                    case RobotEnums.Facing.West:
                        Robot.Position.Facing = RobotEnums.Facing.North;
                        break;
                    case RobotEnums.Facing.North:
                        Robot.Position.Facing = RobotEnums.Facing.East;
                        break;
                }

                Robot.Battery = Robot.Battery - 2;
                Robot.LastState = RobotEnums.States.Turned;
            }
        }
    }
}