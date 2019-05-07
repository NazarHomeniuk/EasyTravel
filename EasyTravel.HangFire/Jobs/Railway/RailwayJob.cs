using System;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.Core.Models.Railway;
using EasyTravel.Services.Railway;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.HangFire.Jobs.Railway
{
    public class RailwayJob
    {
        private readonly ITripFinder tripFinder;
        private readonly DataContext dataContext;

        public RailwayJob(RailwayFinder tripFinder, DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.tripFinder = tripFinder;
        }

        public async Task FindTrips(RailwayMonitoring monitoring)
        {
            var monitoringResult =
                dataContext.RailwayMonitoring.Include(m => m.Trips).FirstOrDefault(m => m.Id == monitoring.Id);
            if (monitoringResult == null)
            {
                RecurringJob.RemoveIfExists(monitoring.Guid);
                return;
            }

            if (monitoringResult.DepartureDate <= DateTime.Now)
            {
                RecurringJob.RemoveIfExists(monitoring.Guid);
                monitoringResult.IsSuccessful = false;
                monitoringResult.IsInProcess = false;
                dataContext.Entry(monitoringResult).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                return;
            }

            var trips = (await tripFinder.FindTripsAsync(monitoringResult.From, monitoringResult.To,
                monitoringResult.DepartureDate)).ToList().ConvertAll(t => (Train) t);
            if (trips.Any())
            {
                monitoringResult.IsSuccessful = true;
                monitoringResult.IsInProcess = false;
                monitoringResult.Trips = trips;
                dataContext.Entry(monitoringResult).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                RecurringJob.RemoveIfExists(monitoring.Guid);
            }
        }
    }
}
