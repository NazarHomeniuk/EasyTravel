using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Place
    {
        public int Id { get; set; }
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
