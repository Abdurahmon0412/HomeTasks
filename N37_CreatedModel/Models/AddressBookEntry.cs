using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    //AddressBookEntry: A record with properties for a contact's name, email, and phone number.
    public record AddressBookEntry(string Name,string Email,string PhoneNumber);
}
