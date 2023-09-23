using Lesson43_Mutex_HT1.Interfaces;
using Lesson43_Mutex_HT1.Models;

namespace Lesson43_Mutex_HT1.Services
{
    public class UserService : IUserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = new();
        }

        public User Create(User? user)
        {
            if (user != null)
            {
                _users.Add(user);
                return user;
            }

            throw new ArgumentNullException(nameof(user), "user is null");
        }

        public bool Delete(Guid id)
        {
            var foundedUser = _users.FirstOrDefault(user => user.Id == id);
            if (foundedUser != null)
            {
                _users.Remove(foundedUser);
                return true;
            }

            return false;
        }

        public User? Get(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User user)
        {
            var foundedUser = Get(user.Id);
            if (foundedUser != null)
            {
                foundedUser.FirstName = user.FirstName;
                foundedUser.LastName = user.LastName;
                foundedUser.IsActive = user.IsActive;
                return foundedUser;
            }

            throw new ArgumentNullException(nameof(foundedUser), "User not found!");
        }

        public List<User> GetAll()
        {
            return _users.ToList();
        }
    }
}
