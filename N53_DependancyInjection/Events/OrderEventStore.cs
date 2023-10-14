using N53_DependancyInjection.Models;

namespace HomeTask52_Events.Events;

public class OrderEventStore
{
    public event Func<Order, ValueTask>? OrderCreatedEvent;

    public async ValueTask CreateOrderEventAsync(Order order)
    {
        if (order != null)
            await OrderCreatedEvent.Invoke(order);
    }
}
