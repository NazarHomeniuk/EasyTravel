using System;

namespace EasyTravel.API.ViewModels.Monitoring
{
    public class BusMonitoringViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
