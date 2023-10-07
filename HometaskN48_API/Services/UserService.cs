using HometaskN48_API.DataAccess;
using HometaskN48_API.Models;
using System.Linq.Expressions;

namespace HometaskN48_API.Services
{
    public class UserService
    {
        private readonly IDataContext _dataContext;

        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _dataContext.Users.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var users = _dataContext.Users.Where(user => ids.Contains(user.Id));
            return new ValueTask<ICollection<User>>(users.ToList());
        }

        public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = _dataContext.Users.FirstOrDefault(user => user.Id == id);

            return new ValueTask<User?>(user);
        }

        public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await _dataContext.Users.AddAsync(user, cancellationToken);

            if (saveChanges)
                await _dataContext.SaveChangesAsync();

            return user;
        }

        public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundUser = _dataContext.Users.FirstOrDefault(searchingUser => searchingUser.Id == user.Id);

            if (foundUser is null)
                throw new InvalidOperationException("User not found");

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.EmailAddress = user.EmailAddress;

            await _dataContext.SaveChangesAsync();
            return foundUser;
        }


        public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundUser = await GetByIdAsync(id, cancellationToken);
            if (foundUser is null)
                throw new InvalidOperationException("User not found");

            await _dataContext.Users.RemoveAsync(foundUser, cancellationToken);
            await _dataContext.SaveChangesAsync();
            return foundUser;
        }

        public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
            => await DeleteAsync(user.Id, saveChanges, cancellationToken);
        
    }
}
