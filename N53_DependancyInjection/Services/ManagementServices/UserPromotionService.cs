using N53_DependancyInjection.Events;
using N53_DependancyInjection.Models;
using N53_DependancyInjection.Services.Interfaces;

namespace N53_DependancyInjection.Services.ManagementServices;

public class UserPromotionService
{
    private BonusEventStore _bonusEventStore;
    private IEnumerable<INotificationService> _notificationService;

    public UserPromotionService(BonusEventStore bonusEventStore,
        IEnumerable<INotificationService> notificationServices)
    {
        _bonusEventStore = bonusEventStore;
        _notificationService = notificationServices;

        _bonusEventStore.BonusAchievedEvent += HandleAchievedBonusEventAsync;
    }

    public async ValueTask HandleAchievedBonusEventAsync(Bonus bonus)
    {
        foreach (var notification in _notificationService)
            await notification.SendAsync(bonus.UserId, "bonus is created");
    }
}
