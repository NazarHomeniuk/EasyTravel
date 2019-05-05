using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EasyTravel.Core.Models.Railway
{
    [DataContract]
    public class Child
    {
        public int Id { get; set; }
        [DataMember]
        [JsonProperty("minDate")]
        public string MinDate { get; set; }

        [DataMember]
        [JsonProperty("maxDate")]
        public string MaxDate { get; set; }
    }
}