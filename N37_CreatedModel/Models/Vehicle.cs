using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Vehicle: A record with properties for a vehicle's make, model, and year.
    public record Vehicle(DateTime Make,string Model,int Year);
}
