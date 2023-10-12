using HomeTask52_Events.Models;

namespace HomeTask52_Events.Events;

public class AccountEventStore 
{
    public event Func<User, ValueTask>? OnUserCreated;

    public async ValueTask CreateUserEventAsync(User user)
    {
        if (OnUserCreated != null)
           await OnUserCreated(user);
    }
}