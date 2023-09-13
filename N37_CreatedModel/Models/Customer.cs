using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Customer: A record with properties for a customer's name, email, and phone number.
    public record Customer(string Name,string Email,string PhoneNumber);
}
