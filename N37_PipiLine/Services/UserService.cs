using N37_PipiLine.Enums;
using N37_PipiLine.Models;

namespace N37_PipiLine.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>();
        public bool AddUser(string firstName, string lastName,Status status,string emailAddress)
        {
            _users.Add(new User(firstName, lastName, status,emailAddress));
            return true;
        }
        public  IEnumerable<User> GetUsers()
        {
            foreach(var user in _users)
            {
                yield return user;
            }
        }
    }
}