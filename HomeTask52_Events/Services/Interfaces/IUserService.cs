using HomeTask52_Events.Models;
using System.Linq.Expressions;

namespace HomeTask52_Events.Services.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);
    ValueTask<User> CreateAsync(User user);
}
