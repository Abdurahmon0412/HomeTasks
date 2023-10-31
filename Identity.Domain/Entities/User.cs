using FileBaseContext.Abstractions.Models.Entity;

namespace Identity.Domain.Entities;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public bool IsEmailAddressVerified { get; set; }
}