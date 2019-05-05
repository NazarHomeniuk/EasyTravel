using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Core.Models.Monitoring;
using Newtonsoft.Json;

namespace EasyTravel.Core.Models.Railway
{
    [DataContract]
    public class Train : ITrip
    {
        public int Id { get; set; }
        [DataMember]
        [JsonProperty("num")]
        public string Num { get; set; }

        [DataMember]
        [JsonProperty("category")]
        public int Category { get; set; }


        [DataMember]
        [JsonProperty("departureDate")]
        public DateTime DepartureDate { get; set; }


        [DataMember]
        [JsonProperty("arrivalDate")]
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        [JsonProperty("isTransformer")]
        public int IsTransformer { get; set; }

        [DataMember]
        [JsonProperty("travelTime")]
        public string TravelTime { get; set; }

        [DataMember]
        [JsonProperty("from")]
        public Station From { get; set; }

        [DataMember]
        [JsonProperty("to")]
        public Station To { get; set; }

        [DataMember]
        [JsonProperty("types")]
        public IEnumerable<Type> Types { get; set; }

        [DataMember]
        [JsonProperty("child")]
        public Child Child { get; set; }

        [DataMember]
        [JsonProperty("allowStudent")]
        public int AllowStudent { get; set; }

        [DataMember]
        [JsonProperty("allowBooking")]
        public int AllowBooking { get; set; }

        [DataMember]
        [JsonProperty("isCis")]
        public int IsCis { get; set; }

        [DataMember]
        [JsonProperty("isEurope")]
        public int IsEurope { get; set; }

        [DataMember]
        [JsonProperty("allowPrivilege")]
        public int AllowPrivilege { get; set; }

        [DataMember]
        [JsonProperty("noReserve")]
        public int NoReserve { get; set; }

        [DataMember]
        [JsonProperty("bookingLink")]
        public string BookingLink { get; set; }

        public RailwayMonitoring Monitoring { get; set; }

        public int RailwayMonitoringId { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{From} - {To}\n");
            foreach (var type in Types)
            {
                stringBuilder.AppendLine(type.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}