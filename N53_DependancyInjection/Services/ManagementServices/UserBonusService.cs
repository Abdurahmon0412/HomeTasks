using HomeTask52_Events.Events;
using HometaskN48_API.Services.Interfaces;
using N53_DependancyInjection.Events;
using N53_DependancyInjection.Models;
using N53_DependancyInjection.Services.Interfaces;

namespace N53_DependancyInjection.Services.ManagementServices;

public class UserBonusService
{
    private IUserService _userService { get; set; }
    private IBonusService _bonusService { get; set; }
    private IEnumerable<INotificationService> _notificationService { get; set; }
    private BonusEventStore _bonusEventStore { get; set; }
   private OrderEventStore _orderEventStory {  get; set; }

    public UserBonusService(OrderEventStore orderEventStory,
        IUserService userService, IBonusService bonusService,
        BonusEventStore bonusEventStore, IEnumerable<INotificationService> notificationServices)
    {
        _userService = userService;
        _bonusService = bonusService;
        _notificationService = notificationServices;
        _bonusEventStore = bonusEventStore;
        _orderEventStory = orderEventStory;

        _orderEventStory.OrderCreatedEvent += HandleOrderCreatedEventAsync;
    }

    public async ValueTask HandleOrderCreatedEventAsync(Order order)
    {
        var user = await _userService.GetByIdAsync(order.UserId);
        var bonus = _bonusService.Get(bonus => bonus.UserId.Equals(user.Id)).FirstOrDefault();

        var oldBonuses = bonus.BonusAmount.ToString().Length;
        var newBonuses = (bonus.BonusAmount + order.Amount).ToString().Length;

        var updatedBonus = new Bonus(bonus.Id,bonus.UserId, bonus.BonusAmount + order.Amount);

        await _bonusService.UpdateAsync(updatedBonus);


        if (oldBonuses < newBonuses)
        {
            await _bonusEventStore.CreateOrderEventAsync(bonus);
            return;
        }


        var stringLength = "1";
        for (int i = 0; i < oldBonuses; i++)
        {
            stringLength += "0";
        }

        var num = int.Parse(stringLength);

        foreach (var service in _notificationService)
        {
            await service.SendAsync(user.Id, $"you can take bonus if gain this {num - bonus.BonusAmount} amount :)");
        }
    }
}
