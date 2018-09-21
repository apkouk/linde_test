using linde_test.Interfaces;
using linde_test.Classes.Escenario;

namespace linde_test.Classes.Movements
{
    public class TurnLeft : IMovement
    {
        private Robot Robot;
        public TurnLeft(Robot robot)
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
                        Robot.Position.Facing = RobotEnums.Facing.North;
                        break;
                    case RobotEnums.Facing.South:
                        Robot.Position.Facing = RobotEnums.Facing.East;
                        break;
                    case RobotEnums.Facing.West:
                        Robot.Position.Facing = RobotEnums.Facing.South;
                        break;
                    case RobotEnums.Facing.North:
                        Robot.Position.Facing = RobotEnums.Facing.West;
                        break;
                }
                Robot.LastState = RobotEnums.States.Turned;
            }
        }

        public void UpdateBattery()
        {
            Robot.Battery = Robot.Battery - 2;           
        }
    }
}