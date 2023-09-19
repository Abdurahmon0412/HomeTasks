using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson41_HT2.Interfaces
{
    public interface IEmailSenderService
    {
         public ValueTask SendEmailAsync(string emailAddress, string fullName);
    }
}
