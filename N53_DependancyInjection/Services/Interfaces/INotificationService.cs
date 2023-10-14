namespace N53_DependancyInjection.Services.Interfaces;

public interface INotificationService
{
    ValueTask SendAsync(Guid userId, string content);
}
