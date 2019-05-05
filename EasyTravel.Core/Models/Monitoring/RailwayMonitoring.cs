using System;
using System.Collections.Generic;
using EasyTravel.Core.Models.Railway;

namespace EasyTravel.Core.Models.Monitoring
{
    public class RailwayMonitoring
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public List<Train> Trips { get; set; }
        public bool IsInProcess { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
