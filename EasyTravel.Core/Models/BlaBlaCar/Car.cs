using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Car
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("comfort")]
        public string Comfort { get; set; }
    }
}
