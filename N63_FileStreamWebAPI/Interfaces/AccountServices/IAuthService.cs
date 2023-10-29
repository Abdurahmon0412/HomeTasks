using N63_FileStreamWebAPI.Dtos;

namespace N63_FileStreamWebAPI.Interfaces.AccountServices;


public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);
}