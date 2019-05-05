using System;
using System.Collections.Generic;

namespace EasyTravel.Contracts.Interfaces.Core
{
    public interface IMonitoring
    {
        int Id { get; set; }
        string From { get; set; }
        string To { get; set; }
        DateTime DepartureDate { get; set; }
        List<ITrip> Trips { get; set; }
        bool IsInProcess { get; set; }
        bool IsSuccessful { get; set; }
    }
}
