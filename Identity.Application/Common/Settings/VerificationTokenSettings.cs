namespace Identity.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string IdentityVerificationTokenPurpose { get; set; } = default!;

    public int IdentityVerificationExpirationDurationInMinutes { get; set; }

    public string VerificationServiceType { get; set; } = default!;
}