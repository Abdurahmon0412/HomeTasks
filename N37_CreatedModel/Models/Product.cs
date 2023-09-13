using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Product: A record with properties for a product's ID, name, and price.
    public record Product(int Id, string Name,decimal Price);
}
