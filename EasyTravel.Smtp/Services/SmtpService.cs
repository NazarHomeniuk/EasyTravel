using System.Net;
using System.Net.Mail;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.Monitoring;
using Microsoft.Extensions.Options;

namespace EasyTravel.Smtp.Services
{
    public class SmtpService
    {
        private readonly SmtpConfig smtpConfig;
        private readonly MailAddress from;
        private SmtpClient smtpClient;

        public SmtpService(IOptions<SmtpConfig> options)
        {
            smtpConfig = options.Value;
            from = new MailAddress(smtpConfig.Email, smtpConfig.Sender);
        }

        public void SendVerificationCode(int code, string email)
        {
            var to = new MailAddress(email);
            var message = new MailMessage(from, to)
            {
                Subject = "Підтвердження електронної пошти",
                Body = $"Код підтвердження: {code}",
                IsBodyHtml = true
            };
            SendEmail(message);
        }

        public void SendBusNotification(BusMonitoring busMonitoring, string email)
        {
            var to = new MailAddress(email);
            var message = new MailMessage(from, to)
            {
                Subject = $"{busMonitoring.From} - {busMonitoring.To}. Поїздки знайдено!",
                Body = "<h2>Автобуси</h2>",
                IsBodyHtml = true
            };
            SendEmail(message);
        }

        public void SendRailwayNotification(RailwayMonitoring railwayMonitoring, string email)
        {
            var to = new MailAddress(email);
            var message = new MailMessage(from, to)
            {
                Subject = $"{railwayMonitoring.From} - {railwayMonitoring.To}. Поїздки знайдено!",
                Body = "<h2>Потяги</h2>",
                IsBodyHtml = true
            };
            SendEmail(message);
        }

        public void SendBlaBlaCarNotification(BlaBlaCarMonitoring blaBlaCarMonitoring, string email)
        {
            var to = new MailAddress(email);
            var message = new MailMessage(from, to)
            {
                Subject = $"{blaBlaCarMonitoring.From} - {blaBlaCarMonitoring.To}. Поїздки знайдено!",
                Body = "<h2>BlaBlaCar</h2>",
                IsBodyHtml = true
            };
            SendEmail(message);
        }

        private void SendEmail(MailMessage message)
        {
            smtpClient = new SmtpClient(smtpConfig.Server, smtpConfig.Port)
            {
                Credentials = new NetworkCredential(smtpConfig.Email, smtpConfig.Password),
                EnableSsl = true
            };
            smtpClient.Send(message);
        }
    }
}
