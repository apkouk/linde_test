﻿using linde_test.Interfaces;
using linde_test.Classes.Escenario;


namespace linde_test.Classes.Movements
{
    public class MoveForward : IMovement
    {
        private Robot Robot;
        public MoveForward(Robot robot)
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
                        Robot.Position.Location.X++;
                        break;
                    case RobotEnums.Facing.South:
                        Robot.Position.Location.Y++;
                        break;
                    case RobotEnums.Facing.West:
                        Robot.Position.Location.X--;
                        break;
                    case RobotEnums.Facing.North:
                        Robot.Position.Location.Y--;
                        break;
                }
                Robot.Battery = Robot.Battery - 3;
                Robot.LastState = RobotEnums.States.Moved;
            }
        }
    }
}