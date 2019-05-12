using System;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Bus;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.Services.Bus;
using EasyTravel.Sms.Services;
using EasyTravel.Smtp.Services;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.HangFire.Jobs.Bus
{
    public class BusJob
    {
        private readonly ITripFinder tripFinder;
        private readonly DataContext dataContext;
        private readonly SmtpService smtpService;
        private readonly SmsService smsService;

        public BusJob(BusFinder tripFinder, DataContext dataContext, SmtpService smtpService, SmsService smsService)
        {
            this.dataContext = dataContext;
            this.tripFinder = tripFinder;
            this.smtpService = smtpService;
            this.smsService = smsService;
        }

        public async Task FindTrips(BusMonitoring monitoring)
        {
            var monitoringResult =
                dataContext.BusMonitoring.Include(m => m.Trips).FirstOrDefault(m => m.Id == monitoring.Id);
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
                monitoringResult.DepartureDate)).ToList().ConvertAll(t => (Trip)t);
            if (trips.Any())
            {
                monitoringResult.IsSuccessful = true;
                monitoringResult.IsInProcess = false;
                monitoringResult.Trips = trips;
                dataContext.Entry(monitoringResult).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                var user = await dataContext.Users.FindAsync(monitoringResult.UserId);
                if (user.EmailNotificationEnabled)
                {
                    await smtpService.SendBusNotification(monitoringResult, user.Email);
                }

                if (user.SmsNotificationEnabled)
                {
                    smsService.SendBusNotification(monitoringResult, user.PhoneNumber);
                }

                RecurringJob.RemoveIfExists(monitoring.Guid);
            }
        }
    }
}
