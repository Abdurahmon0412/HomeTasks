using HomeTask62_Tokens.Models.Dtos;
using HomeTask62_Tokens.Models.Entities;
using System.Security.Authentication;

namespace HomeTask62_Tokens.Services;

public class LoginService
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public LoginService(TokenGeneratorService tokenGeneratorService) => _tokenGeneratorService = tokenGeneratorService;

    private static readonly List<User> _users = new List<User>();

    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            Password = registrationDetails.Password,
        };

        _users.Add(user);

        return new ValueTask<bool>(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.EmailAddress.Equals(loginDetails.EmailAddress)
        && user.Password.Equals(loginDetails.Password));

        if (foundUser == null)
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);

        return new ValueTask<string>(accessToken);
    }

}