using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.HangFire.Jobs.Railway;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasyTravel.HangFire.Services
{
    public class RailwayMonitoringService : IRailwayMonitoringService
    {
        private readonly DataContext dataContext;
        private readonly HangFireConfig hangFireConfig;

        public RailwayMonitoringService(DataContext dataContext, IOptions<HangFireConfig> options)
        {
            this.dataContext = dataContext;
            hangFireConfig = options.Value;
        }

        public async Task StartMonitoring(string from, string to, DateTime departureDate, string placesType, int minPlaces, string userId)
        {
            var user = await dataContext.Users.Include(u => u.RailwayMonitoring)
                .FirstOrDefaultAsync(u => u.Id == userId);
            var monitoring = new RailwayMonitoring
            {
                Guid = Guid.NewGuid().ToString(),
                DepartureDate = departureDate,
                From = from,
                To = to,
                PlacesType = placesType,
                MinPlaces = minPlaces,
                IsInProcess = true
            };
            user.RailwayMonitoring.Add(monitoring);
            dataContext.Entry(user).State = EntityState.Modified;
            dataContext.SaveChanges();
            RecurringJob.AddOrUpdate<RailwayJob>(monitoring.Guid, j => j.FindTrips(monitoring),
                hangFireConfig.MonitoringCron);
        }

        public async Task StopMonitoring(string id)
        {
            var monitoring = await dataContext.RailwayMonitoring.FirstOrDefaultAsync(m => m.Guid == id);
            if (monitoring != null)
            {
                dataContext.RailwayMonitoring.Remove(monitoring);
                RecurringJob.RemoveIfExists(monitoring.Guid);
            }
        }

        public async Task<IEnumerable<IMonitoring>> GetAllMonitoringForUser(string userId)
        {
            var user = await dataContext.Users.Include(u => u.RailwayMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.From)
                .Include(u => u.RailwayMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.To)
                .Include(u => u.RailwayMonitoring).ThenInclude(t => t.Trips).ThenInclude(t => t.Types)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user?.RailwayMonitoring.ToList() ?? new List<RailwayMonitoring>();
        }
    }
}
