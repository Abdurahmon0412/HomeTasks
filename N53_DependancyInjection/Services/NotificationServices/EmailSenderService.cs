﻿using N53_DependancyInjection.Services.Interfaces;

namespace N53_DependancyInjection.Services.NotificationServices;

public class EmailSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Send Email to {userId} with content: {content}");

        return new ValueTask();
    }
}
