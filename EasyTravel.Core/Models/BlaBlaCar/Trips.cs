using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Trips
    {
        [JsonProperty("trips")]
        public Trip[] AvailableTrips { get; set; }
    }
}
