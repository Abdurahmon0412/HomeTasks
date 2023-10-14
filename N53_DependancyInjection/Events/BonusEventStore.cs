using Microsoft.AspNetCore.Http.HttpResults;
using N53_DependancyInjection.Models;

namespace N53_DependancyInjection.Events;

public class BonusEventStore
{
    public event Func<Bonus, ValueTask>? BonusAchievedEvent;

    public async ValueTask CreateOrderEventAsync(Bonus bonus)
    {
        if (bonus != null)
            await BonusAchievedEvent.Invoke(bonus);
    }
}
