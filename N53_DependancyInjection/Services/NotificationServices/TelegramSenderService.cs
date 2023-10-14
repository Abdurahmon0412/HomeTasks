using N53_DependancyInjection.Services.Interfaces;

namespace N53_DependancyInjection.Services.NotificationServices;

public class TelegramSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Send Message to {userId} with content: {content}");

        return new ValueTask();
    }
}
