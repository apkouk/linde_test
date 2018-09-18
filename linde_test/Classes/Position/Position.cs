namespace linde_test.Classes.Position
{
    public class Position
    {
        public Location.Location Location;
        public RobotEnums.Facing Facing;

        public Position(Location.Location location, RobotEnums.Facing facing)
        {
            Location = location;
            Facing = facing;
        }
    }
}