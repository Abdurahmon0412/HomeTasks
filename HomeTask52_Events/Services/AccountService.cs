using HomeTask52_Events.Events;
using HomeTask52_Events.Models;
using HomeTask52_Events.Services.Interfaces;

namespace HomeTask52_Events.Services;

public class AccountService : IAccountService
{
    private IEmailSenderService _emailSenderService;
    private AccountEventStore _eventStore;

    public AccountService(IEmailSenderService emailSenderService, AccountEventStore accountEventStore)
    {
        _eventStore = accountEventStore;
        _emailSenderService = emailSenderService;

        _eventStore.OnUserCreated += HandleUserCreatedEventAsync;
    }

    public async ValueTask HandleUserCreatedEventAsync(User user)
    {
        await _emailSenderService.SendEmailAsync(user);
    }
}