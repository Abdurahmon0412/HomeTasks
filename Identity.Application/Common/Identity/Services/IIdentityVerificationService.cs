using Identity.Domain.Entities;
using Identity.Domain.Enums;

namespace Identity.Application.Common.Identity.Services;

public interface IIdentityVerificationService
{
    ValueTask<string > GenerateVerificationCode(VerificationType verificationType, Guid userId);

    (VerificationCode Code, bool IsValid) VerifyUser(string code);
}