using System.Collections;

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
    }
}