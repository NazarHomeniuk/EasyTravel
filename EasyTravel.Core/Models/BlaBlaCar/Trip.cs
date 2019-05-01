using System;
using EasyTravel.Contracts.Interfaces;
using Newtonsoft.Json;

namespace EasyTravel.Core.Models.BlaBlaCar
{
    public class Trip : ITrip
    {
        [JsonProperty("links")]
        public Links Links { get; set; }
        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }
        [JsonProperty("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonProperty("departure_place")]
        public Place DeparturePlace { get; set; }
        [JsonProperty("arrival_place")]
        public Place ArrivalPlace { get; set; }
        [JsonProperty("price")]
        public Price Price { get; set; }
        [JsonProperty("seats_left")]
        public int SeatsLeft { get; set; }
        [JsonProperty("seats")]
        public int Seats { get; set; }
        [JsonProperty("duration")]
        public Duration Duration { get; set; }
        [JsonProperty("distance")]
        public Distance Distance { get; set; }
        [JsonProperty("car")]
        public Car Car { get; set; }
        [JsonProperty("locations_to_display")]
        public string[] LocationsToDisplay { get; set; }
    }
}
