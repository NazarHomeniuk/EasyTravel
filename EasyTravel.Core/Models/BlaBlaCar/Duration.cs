using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Duration
    {
        public int Id { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("unity")]
        public string Unity { get; set; }
    }
}
