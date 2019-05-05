using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EasyTravel.Core.Models.Railway
{
    [DataContract]
    public class Type
    {
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("id")]
        public string TypeId { get; set; }

        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        [DataMember]
        [JsonProperty("letter")]
        public string Letter { get; set; }

        [DataMember]
        [JsonProperty("places")]
        public uint Places { get; set; }

        public Train Train { get; set; }

        public int TrainId { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Places}";
        }
    }
}