#pragma warning disable CS8618

namespace FileUpload.Models.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; } 

    public bool ValidateIssuer { get; set; }

    public string ValidIssuer { get; set; }

    public bool ValidateAudience { get; set; }

    public string ValidAudience { get; set; }

    public int ExpirationTimeInMinutes { get; set; }

    public bool ValidateLifeTime { get; set; }

    public bool ValidateSigningKey { get; set; }
}