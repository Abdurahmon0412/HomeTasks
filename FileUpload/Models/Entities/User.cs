using FileBaseContext.Abstractions.Models.Entity;

namespace FileUpload.Models.Entities;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
}