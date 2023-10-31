using FileBaseContext.Abstractions.Models.Entity;
using Identity.Domain.Enums;

namespace Identity.Domain.Entities;

public class VerificationCode
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public VerificationType Type { get; set; }

    public  DateTimeOffset ExpiryTime { get; set; }

    public string? Code { get; set; }
}