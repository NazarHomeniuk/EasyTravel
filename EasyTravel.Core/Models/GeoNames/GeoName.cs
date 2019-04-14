namespace EasyTravel.Core.Models
{
    public class GeoName
    {
        public int GeoNameId { get; set; }
        public string Name { get; set; }
        public string AsciiName { get; set; }
        public string AlternateNames { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string FeatureClass { get; set; }
        public string FeatureCode { get; set; }
        public string State { get; set; }
    }
}
