using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Core;

namespace EasyTravel.Contracts.Interfaces.Services.HangFire
{
    public interface IBusMonitoringService
    {
        Task StartMonitoring(string from, string to, DateTime departureDate, string userId);

        Task<IEnumerable<IMonitoring>> GetAllMonitoringForUser(string userId);
    }
}