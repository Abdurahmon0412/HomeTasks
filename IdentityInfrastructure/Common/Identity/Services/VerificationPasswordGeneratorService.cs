using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Application.Foundations;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Common.Identity.Services;

public class VerificationPasswordGeneratorService : IVerificationCodeGeneratorService
{
    private readonly IEntityBaseService<VerificationCode> _verificationCodeService;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationPasswordGeneratorService( IEntityBaseService<VerificationCode> verificationCodeService,
        IOptions<VerificationTokenSettings > verificationTokenOptions)
    {
        _verificationCodeService = verificationCodeService;
        _verificationTokenSettings = verificationTokenOptions.Value;
    }

    public async ValueTask<string> GenerateCode(VerificationType verificationType, Guid userId)
    {
        var code = new VerificationCode
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Type = verificationType,
            ExpiryTime = DateTime.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes),
            Code = new Random().Next(100000, 999999).ToString()
        };

        await _verificationCodeService.CreateAsync(code);

        return code.Code;
    }
 
    public (VerificationCode Token, bool IsValid) VerifyCode(string code)
    {
        if(string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Invalid Verificatin Code!");

        var foundCode = _verificationCodeService.Get(code => true)
            .FirstOrDefault(self => self.Code == (code))
            ?? throw new ArgumentException("Invalid Verificatin Code!");
        
        return (foundCode, foundCode.ExpiryTime > DateTimeOffset.UtcNow);
    }
}