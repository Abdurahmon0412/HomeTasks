using N37_PipiLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_PipiLine.Services
{
//    NotificationManagementService - composition service, uni ichida UserService,
//    EmailTemplateService va EmailSenderService dan instance bo'ladi
//    - bu composition service boshqa servicelardagi yield return qiladigan iterator
//    methodlarni bir biriga ulab pipeline qilib ishlatadi : 
    public class NotificationManagementService
    {
        private UserService _userService;
        private EmailTemplateService _emailTemplateService;
        private EmailService _emailService;
        private EmailSenderService _emailSenderService;
        public NotificationManagementService()
        {
            _userService = new UserService();
            _emailTemplateService = new EmailTemplateService();
            _emailService = new EmailService();
            _emailSenderService = new EmailSenderService();
        }
        public bool NotifyUsers()
        {
            var users = _userService.GetUsers();
            var templates = _emailTemplateService
                .GetEmilTemplate(users,new ("asdj","ajsl;da"));
            var template = templates.FirstOrDefault();
            //var messages = _emailService.GetMessages(users,templates.ToList());

            Console.WriteLine("Email jonatildi!");
            //await _emailSenderService.SendEmailAsync();
            return true;

        }


    }
}
