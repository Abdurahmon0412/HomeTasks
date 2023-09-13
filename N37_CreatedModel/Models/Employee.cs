using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Employee: A record with properties for an employee's name, department, and salary.
    public record Employee(string Name,string Department,decimal Salary);
}
