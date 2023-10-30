using FileUpload.Models.Entities;
using FileUpload.Presentation;

namespace FileUpload.Services.Foundations;

public class UserService
{
    private readonly IDataContext _dataContext;

    public UserService(IDataContext dataContext) => _dataContext = dataContext;

    public async ValueTask<User> CreateUserAsync(User user)
    {
        if(!IsValidUser(user)) throw new ArgumentException("Invalid this User");

        if(!IsUniqueUser(user)) throw new ArgumentException("This user already exists");

        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();

        return user;
    }

    public User GetUserByEmail(string email)
        => _dataContext.Users.FirstOrDefault(user => user.Email == email)
            ?? throw new ArgumentException("User not found!");
    private bool IsValidUser(User user)
        => !string.IsNullOrWhiteSpace(user.UserName)
        || !string.IsNullOrWhiteSpace(user.FirstName)
        || !string.IsNullOrWhiteSpace(user.LastName)
        || !string.IsNullOrWhiteSpace(user.Email)
        || !string.IsNullOrWhiteSpace(user.PasswordHash);

    private bool IsUniqueUser(User user) 
        => !_dataContext.Users.Any(u => u.Email == user.Email);
}