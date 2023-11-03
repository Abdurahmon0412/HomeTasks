using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Persistance.DataContexts;
using System.Linq.Expressions;

namespace EduCource.Infrastructure.Foundations;

public class UserService : IEntityBaseService<User>
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext) => _appDbContext = appDbContext;
    
    public async ValueTask<User> CreateAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);

        await _appDbContext.SaveChangesAsync();

        return user;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _appDbContext.Users.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<User> GetByIdAsync(Guid id)
        => await _appDbContext.Users.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "User not found!");

    public async ValueTask<User> UpdateAsync(User user)
    {
        var foundUser = await GetByIdAsync(user.Id);

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;

        _appDbContext.Users.Update(foundUser);

        await _appDbContext.SaveChangesAsync();
        return foundUser;
    }

    public async ValueTask<User> DeleteByIdAsync(Guid userId)
    {
        var foundUser = _appDbContext.Users.Find(userId);

        if (foundUser is null)
            throw new InvalidOperationException($"User with id {userId} not found.");

        _appDbContext.Users.Remove(foundUser);

        await _appDbContext.SaveChangesAsync();

        return foundUser;
    }
    public async ValueTask<User> DeleteAsync(User user)
    {
        _appDbContext.Remove(user);
        await _appDbContext.SaveChangesAsync();

        return user;
    }
}