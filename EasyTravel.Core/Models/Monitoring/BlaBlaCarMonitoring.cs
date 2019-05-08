using System;
using System.Collections.Generic;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Core.Models.BlaBlaCar;

namespace EasyTravel.Core.Models.Monitoring
{
    public class BlaBlaCarMonitoring : IMonitoring
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int MinPlaces { get; set; }
        public DateTime DepartureDate { get; set; }
        public List<Trip> Trips { get; set; }
        public bool IsInProcess { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
