namespace Identity.Application.Common.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);
}