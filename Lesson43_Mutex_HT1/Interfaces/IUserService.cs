using Lesson43_Mutex_HT1.Models;

namespace Lesson43_Mutex_HT1.Interfaces
{
    public interface IUserService
    {
        User Create(User user);
        bool Delete(Guid id);
        User Get(Guid id);
        User Update(User user);
        List<User> GetAll();
    }
}
