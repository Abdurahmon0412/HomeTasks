using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
//Order: A record with properties for an order's ID, customer, and items.
    public record Order(int Id,Customer Customer,string Items);
}
