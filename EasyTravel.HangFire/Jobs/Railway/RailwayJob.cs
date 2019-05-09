using System;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.Core.Models.Railway;
using EasyTravel.Services.Railway;
using EasyTravel.Sms.Services;
using EasyTravel.Smtp.Services;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.HangFire.Jobs.Railway
{
    public class RailwayJob
    {
        private readonly ITripFinder tripFinder;
        private readonly DataContext dataContext;
        private readonly SmtpService smtpService;
        private readonly SmsService smsService;

        public RailwayJob(RailwayFinder tripFinder, DataContext dataContext, SmtpService smtpService, SmsService smsService)
        {
            this.dataContext = dataContext;
            this.tripFinder = tripFinder;
            this.smtpService = smtpService;
            this.smsService = smsService;
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
                    monitoringResult.DepartureDate)).ToList().ConvertAll(t => (Train) t)
                .FindAll(t => t.Types.Any(p => p.Places >= monitoring.MinPlaces));
            if (trips.Any())
            {
                if (!string.IsNullOrEmpty(monitoring.PlacesType))
                {
                    trips = trips.FindAll(t =>
                        t.Types.Any(p => p.Letter == monitoring.PlacesType));
                }
                if (trips.Any())
                {
                    monitoringResult.IsSuccessful = true;
                    monitoringResult.IsInProcess = false;
                    monitoringResult.Trips = trips;
                    dataContext.Entry(monitoringResult).State = EntityState.Modified;
                    await dataContext.SaveChangesAsync();
                    var user = await dataContext.Users.FindAsync(monitoringResult.UserId);
                    smtpService.SendRailwayNotification(monitoringResult, user.Email);
                    smsService.SendRailwayNotification(monitoringResult, user.PhoneNumber);
                    RecurringJob.RemoveIfExists(monitoring.Guid);
                }
            }
        }
    }
}
