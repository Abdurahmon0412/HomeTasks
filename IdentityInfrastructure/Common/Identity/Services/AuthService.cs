using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notifications.Services;
using Identity.Domain.Entities;
using System.Security.Authentication;

namespace Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IAccountSerive _accountSerive;
    private readonly IAccessTokenGeneratorService _accessTokenGeneratorService;

    public AuthService(IAccessTokenGeneratorService accessTokenGeneratorService,
        IPasswordHasherService passwordHasherService,
        IEmailSenderService emailSenderService,
        IAccountSerive accountSerive)
    {
        _accessTokenGeneratorService = accessTokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _emailSenderService = emailSenderService;
        _accountSerive = accountSerive;
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            UserName = registrationDetails.UserName,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password),
            IsEmailAddressVerified = false
        };

        await _emailSenderService.SendAsync(user.EmailAddress, "Welcome to our Platform");

        await _accountSerive.CreateAsync(user);

        return true;
    }

    public async ValueTask<string> LogingAsync(LoginDetails loginDetails)
    {
        var user = await _accountSerive.GetUserByUserName(loginDetails.UserName);

        if (!_passwordHasherService.ValidatePassword(loginDetails.Password, user.PasswordHash))
            throw new AuthenticationException("Password or UserName are invalid");

        var accessToken = _accessTokenGeneratorService.GetToken(user);

        return accessToken;
    }
}