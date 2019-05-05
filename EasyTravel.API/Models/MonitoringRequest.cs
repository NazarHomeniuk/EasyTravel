using System;

namespace EasyTravel.API.Models
{
    public class MonitoringRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
