using Microsoft.AspNetCore.Mvc;
using OMS.Interfaces;
using System.Net;
using System.Net.Mail;

namespace OMS.Data
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string recipientEmail, string emailSubject, string emailMessage)
        {
            var senderEmail = "mohamedrayenkadhi40@outlook.com";
            var password = "rayenrayen1234566";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, password),
                UseDefaultCredentials = false
            };

            var mailMessage = new MailMessage(from: senderEmail, to: recipientEmail, emailSubject, emailMessage);
            return client.SendMailAsync(mailMessage);
        }
    }
}
