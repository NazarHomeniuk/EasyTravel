using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Distance
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("unity")]
        public string Unity { get; set; }
    }
}
