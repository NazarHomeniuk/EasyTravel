using System.Text;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.Monitoring;
using Microsoft.Extensions.Options;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EasyTravel.Sms.Services
{
    public class SmsService
    {
        private readonly TwilioRestClient twilioRestClient;
        private readonly SmsConfig smsConfig;

        public SmsService(IOptions<SmsConfig> options)
        {
            smsConfig = options.Value;
            twilioRestClient = new TwilioRestClient(smsConfig.Sid, smsConfig.Token);
        }

        public void SendBusNotification(BusMonitoring busMonitoring, string phoneNumber)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{busMonitoring.From} - {busMonitoring.To}. Поїздки знайдено!");
            stringBuilder.AppendLine("Автобуси");
            foreach (var busMonitoringTrip in busMonitoring.Trips)
            {
                stringBuilder.AppendLine(
                    $"{busMonitoringTrip.From} - {busMonitoringTrip.To}: {busMonitoringTrip.DepartureDate}");
            }
            MessageResource.Create(
                from: new PhoneNumber(smsConfig.Number), 
                to: new PhoneNumber(phoneNumber),
                body: stringBuilder.ToString(),
                client: twilioRestClient);
        }

        public void SendRailwayNotification(RailwayMonitoring railwayMonitoring, string phoneNumber)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{railwayMonitoring.From} - {railwayMonitoring.To}. Поїздки знайдено!");
            stringBuilder.AppendLine("Потяги");
            foreach (var railwayMonitoringTrip in railwayMonitoring.Trips)
            {
                stringBuilder.AppendLine(
                    $"{railwayMonitoringTrip.From.StationTrain} - {railwayMonitoringTrip.To.StationTrain}: {railwayMonitoringTrip.DepartureDate}");
            }
            MessageResource.Create(
                from: new PhoneNumber(smsConfig.Number),
                to: new PhoneNumber(phoneNumber),
                body: stringBuilder.ToString(),
                client: twilioRestClient);
        }

        public void SendBlaBlaCarNotification(BlaBlaCarMonitoring blaBlaCarMonitoring, string phoneNumber)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{blaBlaCarMonitoring.From} - {blaBlaCarMonitoring.To}. Поїздки знайдено!");
            stringBuilder.AppendLine("BlaBlaCar");
            foreach (var blaBlaCarMonitoringTrip in blaBlaCarMonitoring.Trips)
            {
                stringBuilder.AppendLine(
                    $"{blaBlaCarMonitoringTrip.DeparturePlace.CityName} - {blaBlaCarMonitoringTrip.ArrivalPlace.CityName}: {blaBlaCarMonitoringTrip.DepartureDate}");
            }
            MessageResource.Create(
                from: new PhoneNumber(smsConfig.Number),
                to: new PhoneNumber(phoneNumber),
                body: stringBuilder.ToString(),
                client: twilioRestClient);
        }
    }
}
