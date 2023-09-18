using Lesson39_HT2.Models;
using Lesson39_HT2.Services.Interfaces;

namespace Lesson39_HT2.Services.Services
{
    public class AccountService : IAccountService
    {
        private ISendEmailService _sendEmailService;
        private IValidationService _validationService;
        private List<User> users;

        public AccountService(IValidationService validation,ISendEmailService sendEmailService)
        {
            users = new List<User>();
            _validationService = validation;
            _sendEmailService = sendEmailService;
        }

        public bool Registr(string firsName, string lastName, string email, string password)
        {
            if(!_validationService.IsValidEmail(email) 
                || !_validationService.IsValidPassword(password)) 
                throw new ArgumentException("EmailAdress or Password is not valid");
            if (!_sendEmailService.SendEmail(email, $"{firsName}_{lastName}"))
                throw new InvalidOperationException("Emailga message junatilishda xatolik ruy berdi ");
            if (users.Any(user => user.EmailAddress.Equals(email)))
                throw new Exception("this user Already exists");
            users.Add(new User(firsName, lastName, email, password));
            return true;
        }
    }
}
