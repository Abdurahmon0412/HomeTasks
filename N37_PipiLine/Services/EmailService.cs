using N37_PipiLine.Models;


namespace N37_PipiLine.Services
{
    public class EmailService
    {
        private readonly string _senderEmailAddress;
        public EmailService()
        {
            _senderEmailAddress = "abdurahmonsadriddinov0412@gmil.com";
        }
        public EmailMessage GetMessages(IEnumerable<User> users, EmailTemplate emailTemplate)
        {
            var emailTemplateService = new EmailTemplateService();
            IEnumerable<(string, string, string)> template = emailTemplateService.GetEmilTemplate(users, emailTemplate);
            template.ToList();
            var emilMessage = new EmailMessage(template.First().Item1, template
                .First().Item2, _senderEmailAddress, template.First().Item3);
            return emilMessage;
        }
    }
}
