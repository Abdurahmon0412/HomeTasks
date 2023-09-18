using Lesson39_HT2.Models;
using Lesson39_HT2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lesson39_HT2.Services.Services
{
    public class SendEmailService : ISendEmailService
    {
        public SendEmailService()
        {
            
        }
        public bool SendEmail(string emailAddress, string fullName)
        {
            try
            {
                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("abdurahmonsadriddinov0412@gmail.com", "bypucbhumkeghlab");
                smtp.EnableSsl = true;
                var mail = new MailMessage(Messages.SenderEmailAddress, emailAddress);
                mail.Subject = Messages.Subject.Replace("{{User}}", fullName);
                mail.Body = Messages.Body;
                smtp.SendMailAsync(mail);
                return true;

            }
            catch {  return false; }
        }
    }
}
