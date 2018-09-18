using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linde_test
{
    public class Position
    {
        public Location Location;
        public RobotEnums.Facing Facing;

        public Position(Location location, RobotEnums.Facing facing)
        {
            Location = location;
            Facing = facing;
        }
    }
}