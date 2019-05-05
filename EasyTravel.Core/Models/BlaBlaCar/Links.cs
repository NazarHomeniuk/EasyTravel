using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Links
    {
        public int Id { get; set; }
        [JsonProperty("_self")]
        public string Self { get; set; }
        [JsonProperty("_front")]
        public string Front { get; set; }
    }
}
