using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_Task1_Record.Models
{
    public record Person(string FirstName, string LastName);

    public record UserPerson(string FirstName, string LastName, string EmailAddress, string Password)
        : Person(FirstName, LastName);

    public record Employee(string FirstName, string LastName, string Graduate);

    public record UserEmployee(string FirstName, string LastName,string Graduate, decimal Salary)
        :Employee(FirstName,LastName,Graduate);


    public record Manager(string FirstName, string LastName, string Graduate,decimal Salary,string Password)
        :Employee(FirstName, LastName,Graduate);
};
