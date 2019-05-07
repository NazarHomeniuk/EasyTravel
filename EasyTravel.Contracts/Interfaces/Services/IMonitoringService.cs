using System;
using System.Threading.Tasks;

namespace EasyTravel.Contracts.Interfaces.Services
{
    public interface IMonitoringService
    {
        Task StartMonitoring(string from, string to, DateTime departureDate, string userId);
    }
}