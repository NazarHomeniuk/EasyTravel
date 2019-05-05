using System;

namespace EasyTravel.Contracts.Interfaces.Services
{
    public interface IMonitoringService
    {
        void StartMonitoring(string from, string to, DateTime departureDate);
    }
}