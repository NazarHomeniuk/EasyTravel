using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Contracts.Interfaces.Services.HangFire;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.BlaBlaCar;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasyTravel.HangFire.Services
{
    public class BlaBlaCarMonitoringService : IBlaBlaCarMonitoringService
    {
        private readonly DataContext dataContext;
        private readonly HangFireConfig hangFireConfig;

        public BlaBlaCarMonitoringService(DataContext dataContext, IOptions<HangFireConfig> options)
        {
            this.dataContext = dataContext;
            hangFireConfig = options.Value;
        }

        public async Task StartMonitoring(string from, string to, DateTime departureDate, int minPlaces, string userId)
        {
            var user = await dataContext.Users.Include(u => u.BlaBlaCarMonitoring)
                .FirstOrDefaultAsync(u => u.Id == userId);
            var monitoring = new BlaBlaCarMonitoring
            {
                Guid = Guid.NewGuid().ToString(),
                DepartureDate = departureDate,
                From = from,
                To = to,
                MinPlaces = minPlaces,
                IsInProcess = true
            };
            user.BlaBlaCarMonitoring.Add(monitoring);
            dataContext.Entry(user).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            RecurringJob.AddOrUpdate<BlaBlaCarJob>(monitoring.Guid, j => j.FindTrips(monitoring),
                hangFireConfig.MonitoringCron);
        }

        public async Task<IEnumerable<IMonitoring>> GetAllMonitoringForUser(string userId)
        {
            var user = await dataContext.Users.Include(u => u.BlaBlaCarMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.DeparturePlace)
                .Include(u => u.BlaBlaCarMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.ArrivalPlace)
                .Include(u => u.BlaBlaCarMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.Car)
                .Include(u => u.BlaBlaCarMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.DeparturePlace)
                .Include(u => u.BlaBlaCarMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.Duration)
                .Include(u => u.BlaBlaCarMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.Distance)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user?.BlaBlaCarMonitoring.ToList() ?? new List<BlaBlaCarMonitoring>();
        }
    }
}
