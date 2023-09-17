using System.Collections;

namespace Lesson38_Indexer
{
    public class UserContainer:IEnumerable<User>
    {
        private List<User> _users;
        public UserContainer() 
        {
            _users = new List<User>() { };
        }
        public UserContainer(List<User> users)
        {
            _users = users;
        }

        public Guid AddUser(string firstName, string lastName, string emailAddress)
        {
            var user = new User(firstName,lastName, emailAddress);
            _users.Add(user);
            return user.Id;
        }
        public User this[Guid Id] => _users.First(x => Guid.Equals(x.Id , Id));
        public User this[int Id] => _users[Id];
        
        public User this[string key]  => _users.First(user => 
           user.FirstName.Contains(key)
        || user.LastName.Contains(key)
        || user.EmailAddress.Contains(key));

        IEnumerator<User> IEnumerable<User>.GetEnumerator()
        {
            return _users.GetEnumerator();
        }
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
