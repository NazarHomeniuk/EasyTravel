using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EasyTravel.Core.Models.Railway
{
    [DataContract]
    public class Station
    {
        [DataMember]
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [DataMember]
        [JsonProperty("station")]
        public string StationName { get; set; }

        [DataMember]
        [JsonProperty("stationTrain")]
        public string StationTrain { get; set; }

        [DataMember]
        [JsonProperty("date")]
        public string Date { get; set; }

        [DataMember]
        [JsonProperty("time")]
        public TimeSpan Time { get; set; }

        [DataMember]
        [JsonProperty("sortTime")]
        public string SortTime { get; set; }

        [DataMember]
        [JsonProperty("srcDate")]
        public DateTime SrcDate { get; set; }

        public override string ToString()
        {
            return $"{StationName} - {Time}";
        }
    }
}