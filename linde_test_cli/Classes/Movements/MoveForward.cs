using linde_test_cli.Classes.Escenario;
using linde_test_cli.Interfaces;

namespace linde_test_cli.Classes.Movements
{
    public class MoveForward : IMovement
    {
        public static int BatteryConsuming = 3;
        private readonly Robot _robot;
        public MoveForward(Robot robot)
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
                        _robot.Position.Location.X++;
                        break;
                    case RobotEnums.Facing.South:
                        _robot.Position.Location.Y++;
                        break;
                    case RobotEnums.Facing.West:
                        _robot.Position.Location.X--;
                        break;
                    case RobotEnums.Facing.North:
                        _robot.Position.Location.Y--;
                        break;
                }
                _robot.LastState = RobotEnums.States.Moved;
            }
        }

        public void UpdateBattery()
        {                     
            _robot.Battery -= BatteryConsuming;
        }
    }
}