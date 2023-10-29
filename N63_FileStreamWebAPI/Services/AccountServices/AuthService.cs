using N63_FileStreamWebAPI.Dtos;
using N63_FileStreamWebAPI.Interfaces.AccountServices;
using N63_FileStreamWebAPI.Models.Entities;
using System.Security.Authentication;

namespace N63_FileStreamWebAPI.Services.AccountServices;


public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;

    public AuthService(ITokenGeneratorService tokenGeneratorService, IPasswordHasherService passwordHasherService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
    }

    private static readonly List<User> _users = new();

    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            Email = registrationDetails.EmailAddress,
            Password = _passwordHasherService.HashPassword(registrationDetails.Password)
        };

        _users.Add(user);

        return new(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.Email == loginDetails.EmailAddress && user.Password == loginDetails.Password);
        if (foundUser is null)
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new(accessToken);
    }
}