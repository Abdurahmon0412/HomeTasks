using Identity.Application.Foundations;
using Identity.Domain.Entities;
using Identity.Persistance.DataContext;
using System.Linq.Expressions;

namespace Identity.Infrastructure.Foundations;

public class UserService : IEntityBaseService<User>
{
    private readonly IDataContext _dataContext;

    public UserService(IDataContext dataContext) => _dataContext = dataContext;

    public async ValueTask<User> GetByIdAsync(Guid id)
            => await _dataContext.Users.FindAsync(id) ??
        throw new ArgumentOutOfRangeException(nameof(id), "User not found!");

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
            => _dataContext.Users.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<User> CreateAsync(User user)
    {
        if (!IsValidUser(user))
            throw new ArgumentException("Invalid user");

        if (!IsUnique(user))
            throw new ArgumentException("Username or email address already exists!");

        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user)
    {
        var foundUser = await GetByIdAsync(user.Id);

        foundUser.IsEmailAddressVerified = user.IsEmailAddressVerified;
        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;

        await _dataContext.Users.UpdateAsync(foundUser);

        await _dataContext.SaveChangesAsync();

        return foundUser;
    }

    private bool IsValidUser(User user)
        => !string.IsNullOrWhiteSpace(user.UserName)
            && !string.IsNullOrWhiteSpace(user.FirstName)
            && !string.IsNullOrWhiteSpace(user.LastName)
            && !string.IsNullOrWhiteSpace(user.EmailAddress)
            && !string.IsNullOrWhiteSpace(user.PasswordHash);

    private bool IsUnique(User user)
        => !_dataContext.Users.Any(self => self.UserName == user.UserName || self.EmailAddress == user.EmailAddress);
}
