namespace N63_FileStreamWebAPI.Interfaces.AccountServices;


public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool ValidatePassword(string password, string hashedPassword);
}