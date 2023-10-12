using HomeTask52_Events.Models;

namespace HomeTask52_Events.Services.Interfaces;

public interface IEmailSenderService
{
    Task SendEmailAsync(User user);
}