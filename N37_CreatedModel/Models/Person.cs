using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Person: A record with properties for a person's name, age, and address.
    public record Person(string Name, int Age, string Address);
}
