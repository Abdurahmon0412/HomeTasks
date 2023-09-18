using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson39_HT2.Services.Interfaces
{
    public interface ISendEmailService
    {
        bool SendEmail(string emailAddress, string fullName);
    }
    
}
