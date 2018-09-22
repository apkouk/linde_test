namespace linde_test_cli.Classes.Position
{
    public class Position
    {
        public Location.Location Location { get; set; }
        public RobotEnums.Facing Facing { get; set; }

        public Position(Location.Location location, RobotEnums.Facing facing)
        {
            Location = location;
            Facing = facing;
        }
    }
}