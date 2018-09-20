using System.Collections.Generic;
using Newtonsoft.Json;

namespace linde_test.Classes.JsonObjects
{
    public class OutputFileJson
    {
        [JsonProperty(Order = 1)]
        public List<object> VisitedCells { get; set; }
        [JsonProperty(Order = 2)]
        public string[] SamplesCollected { get; set; }
        [JsonProperty(Order = 3)]
        public int Battery { get; set; }
        [JsonProperty(Order = 4)]
        public PositionJson FinalPosition;
    }
}