using N36_Task3.Models;

namespace N36_Task3.Services
{
    public class UserCrudEntityService
    {
        private List<User> _users;
        public UserCrudEntityService()
        {
            _users = new List<User>();
        }
        public int AddUser(int id,string firstname,string lastname)
        {
            var newUser = new User(id,firstname,lastname);
            _users.Add(newUser);
            return newUser.Id;
        }

        public void UpdateUser(int id ,string firstName, string Lastname)
        {
            var removedUser = _users.FirstOrDefault(user => user.Id == id);
            _users.Remove(removedUser);
            AddUser(id, firstName, Lastname);
        }

        public void DeleteUser(int id)
        {
            var removedUser = _users.FirstOrDefault(user => user.Id == id);
            _users.Remove(removedUser);
        }

        public List<User> GetAllUsers => _users;
    }
}
