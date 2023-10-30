using BC = BCrypt.Net.BCrypt;
namespace FileUpload.Services.Identity;

public class PasswordHashService
{
    public   string HashPassword(string password)
        => BC.HashPassword(password);

    public bool VerifyPassword(string password, string hashedPassword)
        => BC.Verify(password, hashedPassword);
}