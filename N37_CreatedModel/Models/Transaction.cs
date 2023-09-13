using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //Transaction: A record with properties for a transaction's ID, date, and amount.
    public record Transaction(int Id,DateTime Date,decimal Amount);
}
