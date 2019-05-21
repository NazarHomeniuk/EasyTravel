using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Contracts.Interfaces.Services.HangFire;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.Bus;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasyTravel.HangFire.Services
{
    public class BusMonitoringService : IBusMonitoringService
    {
        private readonly DataContext dataContext;
        private readonly HangFireConfig hangFireConfig;

        public BusMonitoringService(DataContext dataContext, IOptions<HangFireConfig> options)
        {
            this.dataContext = dataContext;
            hangFireConfig = options.Value;
        }

        public async Task StartMonitoring(string from, string to, DateTime departureDate, string userId)
        {
            var user = await dataContext.Users.Include(u => u.BusMonitoring)
                .FirstOrDefaultAsync(u => u.Id == userId);
            var monitoring = new BusMonitoring
            {
                Guid = Guid.NewGuid().ToString(),
                DepartureDate = departureDate,
                From = from,
                To = to,
                IsInProcess = true
            };
            user.BusMonitoring.Add(monitoring);
            dataContext.Entry(user).State = EntityState.Modified;
            dataContext.SaveChanges();
            RecurringJob.AddOrUpdate<BusJob>(monitoring.Guid, j => j.FindTrips(monitoring),
                hangFireConfig.MonitoringCron);
        }

        public async Task StopMonitoring(string id)
        {
            var monitoring = await dataContext.BusMonitoring.FirstOrDefaultAsync(m => m.Guid == id);
            if (monitoring != null)
            {
                dataContext.BusMonitoring.Remove(monitoring);
                RecurringJob.RemoveIfExists(monitoring.Guid);
            }
        }

        public async Task<IEnumerable<IMonitoring>> GetAllMonitoringForUser(string userId)
        {
            var user = await dataContext.Users.Include(u => u.BusMonitoring).ThenInclude(t => t.Trips)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user?.BusMonitoring.ToList() ?? new List<BusMonitoring>();
        }
    }
}
