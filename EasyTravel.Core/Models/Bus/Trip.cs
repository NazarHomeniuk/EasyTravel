using System;
using EasyTravel.Contracts.Interfaces;

namespace EasyTravel.Core.Models.Bus
{
    public class Trip : ITrip
    {
        public string From { get; set; }

        public string To { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public DateTime Date { get; set; }

        public int Distance { get; set; }

        public double Price { get; set; }

        public string BusName { get; set; }
    }
}