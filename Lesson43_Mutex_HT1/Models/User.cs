using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson43_Mutex_HT1.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public User()
        {
            
        }
        public User(string firstName, string lastName, bool isActive)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
        }
    }

}
