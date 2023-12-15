using Microsoft.AspNetCore.Mvc;
using OMS.Interfaces;
using System.Net;
using System.Net.Mail;

namespace OMS.Data
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string recipientEmail, string emailSubject, string emailMessage, bool isHtml = true)
        {
            var senderEmail = "OMSsender@outlook.com";
            var password = "AlidadeAlidade";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, password),
                UseDefaultCredentials = false
            };

            var mailMessage = new MailMessage(from: senderEmail, to: recipientEmail, emailSubject, emailMessage)
			{
				IsBodyHtml = isHtml
			};
			return client.SendMailAsync(mailMessage);
        }
    }
}
