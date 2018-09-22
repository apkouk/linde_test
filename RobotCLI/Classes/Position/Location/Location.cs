namespace linde_test_cli.Classes.Position.Location
{
    public class Location
    {
        private int _x;
        public int X
        {
            get => _x;
            set => _x = value < 0 ? 0 : value;
        }

        private int _y;
        public int Y
        {
            get => _y;
            set => _y = value < 0 ? 0 : value;
        }
    }
}
