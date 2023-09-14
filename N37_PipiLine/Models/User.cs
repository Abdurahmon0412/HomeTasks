using N37_PipiLine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_PipiLine.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Status Status { get; set; }
        public string EmailAddress { get; set; }
        public User(string firstName,string lastName,Status status,string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Status = status; 
            EmailAddress = emailAddress;
        }
    }
}
