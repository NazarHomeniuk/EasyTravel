using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Services.Smtp;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.Monitoring;
using Microsoft.Extensions.Options;

namespace EasyTravel.Smtp.Services
{
    public class SmtpService
    {
        private readonly SmtpConfig smtpConfig;
        private readonly MailAddress from;
        private readonly IRazorViewToStringRenderer renderer;
        private SmtpClient smtpClient;

        public SmtpService(IOptions<SmtpConfig> options, IRazorViewToStringRenderer renderer)
        {
            smtpConfig = options.Value;
            from = new MailAddress(smtpConfig.Email, smtpConfig.Sender);
            this.renderer = renderer;
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

        public async Task SendBusNotification(BusMonitoring busMonitoring, string email)
        {
            var to = new MailAddress(email);
            var body = await renderer.RenderViewToStringAsync("Templates/BusNotificationTemplate.cshtml", busMonitoring);
            var message = new MailMessage(from, to)
            {
                Subject = $"{busMonitoring.From} - {busMonitoring.To}. Поїздки знайдено!",
                Body = body,
                IsBodyHtml = true
            };
            SendEmail(message);
        }

        public async Task SendRailwayNotification(RailwayMonitoring railwayMonitoring, string email)
        {
            var to = new MailAddress(email);
            var body = await renderer.RenderViewToStringAsync("Templates/RailwayNotificationTemplate.cshtml", railwayMonitoring);
            var message = new MailMessage(from, to)
            {
                Subject = $"{railwayMonitoring.From} - {railwayMonitoring.To}. Поїздки знайдено!",
                Body = body,
                IsBodyHtml = true
            };
            SendEmail(message);
        }

        public async Task SendBlaBlaCarNotification(BlaBlaCarMonitoring blaBlaCarMonitoring, string email)
        {
            var to = new MailAddress(email);
            var body = await renderer.RenderViewToStringAsync("Templates/BlaBlaCarNotificationTemplate.cshtml", blaBlaCarMonitoring);
            var message = new MailMessage(from, to)
            {
                Subject = $"{blaBlaCarMonitoring.From} - {blaBlaCarMonitoring.To}. Поїздки знайдено!",
                Body = body,
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
