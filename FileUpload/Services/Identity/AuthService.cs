using FileUpload.Models.Entities;
using FileUpload.Models.Identity;
using FileUpload.Services.Foundations;
using System.Security.Authentication;

namespace FileUpload.Services.Identity;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;
    private readonly PasswordHashService _passwordHashService;
    private readonly UserService _userService;

    public AuthService(TokenGeneratorService tokenGeneratorService,
        PasswordHashService passwordHashService,
        UserService userService)
    {
        _passwordHashService = passwordHashService;
        _tokenGeneratorService = tokenGeneratorService;
        _userService = userService;
    }

    public async ValueTask<User> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Email = registrationDetails.Email,
            PasswordHash = _passwordHashService.HashPassword(registrationDetails.Password),
            UserName = registrationDetails.UserName
        };

        var createdUser =  await _userService.CreateUserAsync(user);

        return createdUser;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _userService.GetUserByEmail(loginDetails.Email);

        if (foundUser is null || !_passwordHashService.VerifyPassword(loginDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Login details are invalid");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);

        return new ValueTask<string>(accessToken);
    }
}