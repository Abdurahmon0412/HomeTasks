using Identity.Application.Common.Notifications.Services;
using Identity.Application.Common.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Identity.Infrastructure.Common.Notifications.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailSenderService(IOptions<EmailSenderSettings> emailSenderSettings)
    {
        _emailSenderSettings = emailSenderSettings.Value;
    }

    public ValueTask<bool> SendAsync(string emailAddress, string message)
    {
        var mail = new MailMessage(_emailSenderSettings.CredintialEmailAddress, emailAddress);
        mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
        mail.Body = message;

        var smtpClient  = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port);
        smtpClient.Credentials = new NetworkCredential(_emailSenderSettings.CredintialEmailAddress, _emailSenderSettings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new(true);
    }
}