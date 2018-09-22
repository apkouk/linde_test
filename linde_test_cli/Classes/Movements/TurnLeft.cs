using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Movements
{
    public class TurnLeft : IMovement
    {
        public static int BatteryConsuming = 2;

        private readonly Robot _robot;
        public TurnLeft(Robot robot)
        {
            _robot = robot;
            Move();
        }

        public void Move()
        {
            if (_robot != null)
            {
                switch (_robot.Position.Facing)
                {
                    case RobotEnums.Facing.East:
                        _robot.Position.Facing = RobotEnums.Facing.North;
                        break;
                    case RobotEnums.Facing.South:
                        _robot.Position.Facing = RobotEnums.Facing.East;
                        break;
                    case RobotEnums.Facing.West:
                        _robot.Position.Facing = RobotEnums.Facing.South;
                        break;
                    case RobotEnums.Facing.North:
                        _robot.Position.Facing = RobotEnums.Facing.West;
                        break;
                }
                _robot.LastState = RobotEnums.States.Turned;
            }
        }

        public void UpdateBattery()
        {
            _robot.Battery -= BatteryConsuming;           
        }
    }
}