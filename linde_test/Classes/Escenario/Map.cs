using System.Collections;
using linde_test.Classes.Position.Location;

namespace linde_test.Classes.Escenario
{
    public class Map
    {
        public string[][] Terrain;

        public Map(ArrayList terrain)
        {
            LoadTerrain(terrain);
        }

        public void LoadTerrain(ArrayList propertiesTerrain)
        {
            Terrain = new string[propertiesTerrain.Count][];

            int count = 0;
            foreach (Newtonsoft.Json.Linq.JArray array in propertiesTerrain)
            {
                string[] defArray = new string[array.Count];
                for (int i = 0; i < array.Count; i++)
                {
                    defArray[i] = array.Root[i].ToString();
                }
                Terrain[count] = defArray;
                count++;
            }
        }

        public bool IsNewLocationObs(Position.Position position)
        {
            return GetTerrain(position.Location).Equals("Obs");
        }

        public string GetTerrain(Location location)
        {
            string[] yVal = Terrain[location.Y];
            return yVal[location.X];
        }

        public bool IsLocationOnMapBoundaries(Position.Position position)
        {
            return position.Location.X <= Terrain[0].Length - 1 && position.Location.Y <= Terrain.Length - 1;
        }
    }
}