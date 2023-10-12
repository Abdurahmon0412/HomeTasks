using HomeTask52_Events.Events;
using HomeTask52_Events.Models;
using N52_HT1.DataAccess;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace HomeTask52_Events.Services.Interfaces;

public class UserService : IUserService
{
    private readonly IDataContext _context;
    private readonly AccountEventStore _eventStore;

    public UserService(IDataContext context, AccountEventStore eventStore)
    {
        _context = context;
        _eventStore = eventStore;
    }

    public async ValueTask<User> CreateAsync(User user)
    {
        Validate(user);

        var result = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        await _eventStore.CreateUserEventAsync(user);

        return result.Entity;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _context.Users.Where(predicate.Compile()).AsQueryable();

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName)
            || string.IsNullOrWhiteSpace(user.LastName))
        {
            throw new ArgumentNullException("Invalid full name");
        }

        if (!Regex.IsMatch(user.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
            throw new ArgumentException("Invalid email");
    }
}