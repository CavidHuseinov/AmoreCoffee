using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Amore.Business.Services.Implementations
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _config;
        private readonly INotificationService _notificationService;

        public EmailService(IConfiguration config, INotificationService notificationService)
        {
            _config = config;
            _notificationService = notificationService;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, string? userEmail = null, string? userName = null, string? userComment = null)
        {
            var smtpClient = new SmtpClient(_config["Email:SmtpServer"])
            {
                Port = int.Parse(_config["Email:Port"]),
                Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["Email:From"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);
            await smtpClient.SendMailAsync(mailMessage);
            if (userEmail != null) 
            await _notificationService.AddNotificationAsync(userName,userEmail, userComment);
        }
    }
}
