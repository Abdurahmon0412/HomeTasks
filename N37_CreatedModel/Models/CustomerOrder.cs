using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //CustomerOrder: A record with properties for a customer's name, email, and a list of orders.
    public record CustomerOrder(string Name,string Email,List<Order> orders);
}
