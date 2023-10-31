using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Identity.Infrastructure.Common.Identity.Services
{
    public class VerificationTokenGeneratorService : IVerificationCodeGeneratorService
    {
        private readonly IDataProtector _protector;
        private readonly VerificationTokenSettings _verificationTokenSettings;

        public VerificationTokenGeneratorService(IOptions<VerificationTokenSettings> verificationTokenSettings,
            IDataProtectionProvider dataProtectionProvider)
        {
            _verificationTokenSettings = verificationTokenSettings.Value;
            _protector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
        }

        public ValueTask<string> GenerateCode(VerificationType verificationType, Guid userId)
        {
            var verificationToken = new VerificationCode
            {
                UserId = userId,
                Type = verificationType,
                ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
            };

            return new ( _protector.Protect(JsonConvert.SerializeObject(verificationToken)));
        }

        public (VerificationCode Token, bool IsValid) VerifyCode(string token)
        {
            if(string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            var unprotectedToken = _protector.Unprotect(token);
            var verificationToken = JsonConvert.DeserializeObject<VerificationCode>(unprotectedToken)??
                throw new ArgumentNullException(unprotectedToken);

            return (verificationToken, verificationToken.ExpiryTime >  DateTimeOffset.UtcNow);
        }
    }
}