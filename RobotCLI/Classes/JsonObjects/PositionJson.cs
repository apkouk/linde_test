using System;
using linde_test_cli.Classes.Position.Location;

namespace linde_test_cli.Classes.JsonObjects
{
    public class PositionJson
    {
        private Location _location;
        private string _facing;

        public PositionJson(Location location, RobotEnums.Facing facing)
        {
            _location = location;
            _facing = Enum.GetName(typeof(RobotEnums.Facing), facing);
        }
    }
}