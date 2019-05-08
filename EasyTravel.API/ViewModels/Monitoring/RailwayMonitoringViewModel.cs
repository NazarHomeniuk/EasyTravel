using System;

namespace EasyTravel.API.ViewModels.Monitoring
{
    public class RailwayMonitoringViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string PlacesType { get; set; }
        public int MinPlaces { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
