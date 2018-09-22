using System;
using linde_test_cli.Classes.Position.Location;

namespace linde_test_cli.Classes.JsonObjects
{
    public class PositionJson
    {
        public Location Location;
        public string Facing;

        public PositionJson(Location location, RobotEnums.Facing facing)
        {
            Location = location;
            Facing = Enum.GetName(typeof(RobotEnums.Facing), facing);
        }
    }
}