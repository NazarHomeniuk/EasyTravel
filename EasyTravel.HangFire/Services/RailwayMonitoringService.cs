using System;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.Railway;
using Hangfire;
using Microsoft.Extensions.Options;

namespace EasyTravel.HangFire.Services
{
    public class RailwayMonitoringService : IMonitoringService
    {
        private readonly DataContext dataContext;
        private readonly HangFireConfig hangFireConfig;

        public RailwayMonitoringService(DataContext dataContext, IOptions<HangFireConfig> options)
        {
            this.dataContext = dataContext;
            hangFireConfig = options.Value;
        }

        public void StartMonitoring(string from, string to, DateTime departureDate)
        {
            var monitoring = new RailwayMonitoring
            {
                DepartureDate = departureDate,
                From = from,
                To = to,
                IsInProcess = true
            };
            var monitoringResult = dataContext.RailwayMonitoring.Add(monitoring).Entity;
            dataContext.SaveChanges();
            RecurringJob.AddOrUpdate<RailwayJob>(monitoringResult.Id.ToString(), j => j.FindTrips(monitoringResult),
                hangFireConfig.MonitoringCron);
        }
    }
}
