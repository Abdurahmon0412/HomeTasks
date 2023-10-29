using N63_FileStreamWebAPI.Interfaces.AccountServices;
using BC = BCrypt.Net.BCrypt;

namespace N63_FileStreamWebAPI.Services.AccountServices;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}