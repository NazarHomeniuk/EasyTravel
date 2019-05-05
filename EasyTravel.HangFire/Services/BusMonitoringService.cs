using System;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.Bus;
using Hangfire;
using Microsoft.Extensions.Options;

namespace EasyTravel.HangFire.Services
{
    public class BusMonitoringService : IMonitoringService
    {
        private readonly DataContext dataContext;
        private readonly HangFireConfig hangFireConfig;

        public BusMonitoringService(DataContext dataContext, IOptions<HangFireConfig> options)
        {
            this.dataContext = dataContext;
            hangFireConfig = options.Value;
        }

        public void StartMonitoring(string from, string to, DateTime departureDate)
        {
            var monitoring = new BusMonitoring
            {
                DepartureDate = departureDate,
                From = from,
                To = to,
                IsInProcess = true
            };
            var monitoringResult = dataContext.BusMonitoring.Add(monitoring).Entity;
            dataContext.SaveChanges();
            RecurringJob.AddOrUpdate<BusJob>(monitoringResult.Id.ToString(), j => j.FindTrips(monitoringResult),
                hangFireConfig.MonitoringCron);
        }
    }
}
