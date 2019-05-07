using System;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.BlaBlaCar;
using Hangfire;
using Microsoft.EntityFrameworkCore;
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

        public async Task StartMonitoring(string from, string to, DateTime departureDate, string userId)
        {
            var user = await dataContext.Users.Include(u => u.BlaBlaCarMonitoring)
                .FirstOrDefaultAsync(u => u.Id == userId);
            var monitoring = new BlaBlaCarMonitoring
            {
                Guid = Guid.NewGuid().ToString(),
                DepartureDate = departureDate,
                From = from,
                To = to,
                IsInProcess = true
            };
            user.BlaBlaCarMonitoring.Add(monitoring);
            dataContext.Entry(user).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            RecurringJob.AddOrUpdate<BlaBlaCarJob>(monitoring.Guid, j => j.FindTrips(monitoring),
                hangFireConfig.MonitoringCron);
        }
    }
}
