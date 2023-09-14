using N37_PipiLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace N37_PipiLine.Services
{
    public class EmailSenderService
    {
        public Task SendEmailAsync(User user,string subject,string body)
        {
            try
            {
                var task = Task.Run(() =>
                {

                    var CredentialAddress = "abdurahmonsadriddinov0412@gmail.com";
                    var CredentialPassword = "bypucbhumkeghlab";

                    var mail = new MailMessage(CredentialAddress, user.EmailAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    var smtpClient = new SmtpClient("smtp.gmail.com", 587); //
                    smtpClient.Credentials = new NetworkCredential(CredentialAddress, CredentialPassword);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }); 
                
                return task;
            }
            catch 
            {
                throw new Exception("Email Jo'natib bo'lmadi!");
            }
        }
    }
}
