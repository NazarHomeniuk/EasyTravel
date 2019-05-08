using System;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.BlaBlaCar;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.Services.BlaBlaCar;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.HangFire.Jobs.BlaBlaCar
{
    public class BlaBlaCarJob
    {
        private readonly ITripFinder tripFinder;
        private readonly DataContext dataContext;

        public BlaBlaCarJob(BlaBlaCarFinder tripFinder, DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.tripFinder = tripFinder;
        }

        public async Task FindTrips(BlaBlaCarMonitoring monitoring)
        {
            var monitoringResult =
                dataContext.BlaBlaCarMonitoring.Include(m => m.Trips).FirstOrDefault(m => m.Id == monitoring.Id);
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
                    monitoringResult.DepartureDate)).ToList().ConvertAll(t => (Trip) t)
                .FindAll(t => t.SeatsLeft >= monitoring.MinPlaces);
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
