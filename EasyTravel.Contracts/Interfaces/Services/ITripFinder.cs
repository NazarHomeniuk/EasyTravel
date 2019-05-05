using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Core;

namespace EasyTravel.Contracts.Interfaces.Services
{
    public interface ITripFinder
    {
        Task<IEnumerable<ITrip>> FindTripsAsync(string from, string to, DateTime departureDate);
        Task<IEnumerable<ITrip>> FindAllTripsAsync(string from, string to, DateTime departureDate);
    }
}