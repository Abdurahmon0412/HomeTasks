using Lesson39_HT2.Models;
using Lesson39_HT2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson39_HT2.Services.Services
{
    public class ValidationService : IValidationService
    {
        public bool IsValidEmail(string email) => Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        public bool IsValidPassword(string password) => Regex.IsMatch(password, @"^[A-Za-z0-9]{8,}$");
    }
}
