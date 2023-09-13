using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
//Address: A record with properties for an address's street, city, state, and zip code.
    public record Address(string Street,string City, string State,string ZipCode);
}
