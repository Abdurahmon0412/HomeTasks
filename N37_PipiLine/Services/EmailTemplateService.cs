using N37_PipiLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_PipiLine.Services
{
    public class EmailTemplateService
    {
        public IEnumerable<(string,string,string)> GetEmilTemplate(IEnumerable<User> users, EmailTemplate emailTemplate)
        {
            foreach (var user in users)
            {

                var subject = emailTemplate.Subject
                    .Replace("{{FullName}}", user.FirstName + " " + user.LastName);
                var body = emailTemplate.Body
                    .Replace("{{FullName}}", user.FirstName + " " + user.LastName);
                yield return (subject, body,user.EmailAddress);
          }
        }
    }
}
