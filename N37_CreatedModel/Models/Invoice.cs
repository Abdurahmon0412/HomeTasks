using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Invoice: A record with properties for an invoice's ID, customer, and total amount.
    public record Invoice(int Id,Customer Customer, decimal TotalAmount);
}
