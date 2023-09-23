using System.Net.Mail;
using System.Net;
using Lesson41_HT2.Interfaces;
using Lesson41_HT2.Models;

namespace Lesson41_HT2.Services
{
    internal class EmailSenderService : IEmailSenderService
    {
        private readonly object _lock = new();
        private SmtpClient smtp;
        public EmailSenderService()
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("abdurahmonsadriddinov0412@gmail.com", "bypucbhumkeghlab");
            smtp.EnableSsl = true;

        }
        public async ValueTask SendEmailAsync(string emailAddress, string fullName)
        {




            var mail = new MailMessage(Messages.SenderEmailAddress, emailAddress);
            mail.Subject = Messages.Subject.Replace("{{User}}", fullName);
            mail.Body = Messages.Body;
            lock (_lock)
            {
                smtp.SendMailAsync(mail).Wait();
                return;
            }
        }
    }
}
