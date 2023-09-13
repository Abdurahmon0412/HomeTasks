using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Company: A record with properties for a company's name, address, and phone number.
    public record Company(string Name, string Address,string PhoneNumber);
}
