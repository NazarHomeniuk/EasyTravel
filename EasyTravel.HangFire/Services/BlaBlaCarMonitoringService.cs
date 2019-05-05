using System;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.BlaBlaCar;
using Hangfire;
using Microsoft.Extensions.Options;

namespace EasyTravel.HangFire.Services
{
    public class BlaBlaCarMonitoringService : IMonitoringService
    {
        private readonly DataContext dataContext;
        private readonly HangFireConfig hangFireConfig;

        public BlaBlaCarMonitoringService(DataContext dataContext, IOptions<HangFireConfig> options)
        {
            this.dataContext = dataContext;
            hangFireConfig = options.Value;
        }

        public void StartMonitoring(string from, string to, DateTime departureDate)
        {
            var monitoring = new BlaBlaCarMonitoring
            {
                DepartureDate = departureDate,
                From = from,
                To = to,
                IsInProcess = true
            };
            var monitoringResult = dataContext.BlaBlaCarMonitoring.Add(monitoring).Entity;
            dataContext.SaveChanges();
            RecurringJob.AddOrUpdate<BlaBlaCarJob>(monitoringResult.Id.ToString(), j => j.FindTrips(monitoringResult),
                hangFireConfig.MonitoringCron);
        }
    }
}
