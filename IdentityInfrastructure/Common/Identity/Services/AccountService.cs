using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notifications.Services;
using Identity.Application.Foundations;
using Identity.Domain.Entities;
using Identity.Domain.Enums;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountSerive
{
    private readonly IIdentityVerificationService _identityVerificationService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEntityBaseService<User> _userService;
    public AccountService(IEmailSenderService emailSenderService,
        IEntityBaseService<User> userService,
        IIdentityVerificationService identityVerificationService)
    {
        _emailSenderService = emailSenderService;
        _userService = userService;
        _identityVerificationService = identityVerificationService;
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        var verificationToken = await _identityVerificationService.GenerateVerificationCode(VerificationType.EmailAddressVerification, user.Id);
        await _emailSenderService.SendAsync(user.EmailAddress, verificationToken);
        var createdUser = await _userService.CreateAsync(user);

        return createdUser;
    }

    public async ValueTask<bool> VerificateAsync(string token)
    {
        var verificationToken = _identityVerificationService.VerifyUser(token);
        
        if(!verificationToken.IsValid)
            throw new ArgumentException("Invalid verification token!");

        var result = verificationToken.Code.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerified(verificationToken.Code.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other type of tokens!")
        };

        return await result;
    }

    public ValueTask<User> GetUserByUserName(string userName)
    {
        var users = _userService.Get(user => true);

        var foundUser = users.Single(user => user.UserName == userName);

        return new(foundUser);
    }

    public async ValueTask<bool> MarkEmailAsVerified(Guid userId)
    {
        var foundUser = await _userService.GetByIdAsync(userId);

        foundUser.IsEmailAddressVerified = true;

        await _userService.UpdateAsync(foundUser);

        return true;
    }
}
