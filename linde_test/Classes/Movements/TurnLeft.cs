﻿using linde_test.Interfaces;
using linde_test.Classes.Escenario;

namespace linde_test.Classes.Movements
{
    public class TurnLeft : IMovement
    {
        public void Move(Robot robot)
        {
            switch (robot.Position.Facing)
            {
                case RobotEnums.Facing.East:
                    robot.Position.Facing = RobotEnums.Facing.North;
                    break;
                case RobotEnums.Facing.South:
                    robot.Position.Facing = RobotEnums.Facing.East;
                    break;
                case RobotEnums.Facing.West:
                    robot.Position.Facing = RobotEnums.Facing.South;
                    break;
                case RobotEnums.Facing.North:
                    robot.Position.Facing = RobotEnums.Facing.West;
                    break;
            }

            robot.Battery = robot.Battery - 2;
            robot.LastState = RobotEnums.States.Turned;
        }
    }
}