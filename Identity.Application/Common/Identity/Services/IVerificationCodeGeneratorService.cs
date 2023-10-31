using Identity.Domain.Entities;
using Identity.Domain.Enums;

namespace Identity.Application.Common.Identity.Services;

public interface IVerificationCodeGeneratorService
{
    ValueTask<string> GenerateCode(VerificationType verificationType, Guid userId);

    (VerificationCode Token, bool IsValid) VerifyCode(string token);
}