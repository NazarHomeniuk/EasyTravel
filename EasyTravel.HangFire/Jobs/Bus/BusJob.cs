using System;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Bus;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.Services.Bus;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.HangFire.Jobs.Bus
{
    public class BusJob
    {
        private readonly ITripFinder tripFinder;
        private readonly DataContext dataContext;

        public BusJob(BusFinder tripFinder, DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.tripFinder = tripFinder;
        }

        public async Task FindTrips(BusMonitoring monitoring)
        {
            var monitoringResult =
                dataContext.BusMonitoring.Include(m => m.Trips).FirstOrDefault(m => m.Id == monitoring.Id);
            if (monitoringResult == null)
            {
                RecurringJob.RemoveIfExists(monitoring.Id.ToString());
                return;
            }

            if (monitoringResult.DepartureDate <= DateTime.Now)
            {
                RecurringJob.RemoveIfExists(monitoring.Id.ToString());
                monitoringResult.IsSuccessful = false;
                monitoringResult.IsInProcess = false;
                dataContext.Entry(monitoringResult).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                return;
            }

            var trips = (await tripFinder.FindTripsAsync(monitoringResult.From, monitoringResult.To,
                monitoringResult.DepartureDate)).ToList().ConvertAll(t => (Trip)t);
            if (trips.Any())
            {
                monitoringResult.IsSuccessful = true;
                monitoringResult.IsInProcess = false;
                monitoringResult.Trips = trips;
                dataContext.Entry(monitoringResult).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                RecurringJob.RemoveIfExists(monitoring.Id.ToString());
            }
        }
    }
}
