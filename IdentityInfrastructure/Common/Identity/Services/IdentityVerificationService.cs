using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Domain.Entities;
using Identity.Domain.Enums;

namespace Identity.Infrastructure.Common.Identity.Services;

public class IdentityVerificationService : IIdentityVerificationService
{
    private readonly IEnumerable<IVerificationCodeGeneratorService> _verificationCodeGeneratorService;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public IdentityVerificationService(IEnumerable<IVerificationCodeGeneratorService> verificationCodeGeneratorServices,
        VerificationTokenSettings verificationTokenSettings) 
        =>( _verificationCodeGeneratorService, _verificationTokenSettings) = 
        (verificationCodeGeneratorServices, verificationTokenSettings);
    
    public async ValueTask<string> GenerateVerificationCode(VerificationType verificationType, Guid userId)
    {
        var verificationService = GetVerificationService();

        var code = await verificationService.GenerateCode(verificationType, userId);

        return code;
    }

    public (VerificationCode Code, bool IsValid) VerifyUser(string code)
    {
        var verificationService = GetVerificationService();

        return verificationService.VerifyCode(code);
    }

    private IVerificationCodeGeneratorService GetVerificationService()
       => _verificationCodeGeneratorService
           .FirstOrDefault(service => service
               .GetType().Name
                   .Contains(_verificationTokenSettings.VerificationServiceType))
           ?? throw new InvalidOperationException("Invalid verification service type specified in configuration.");

}
