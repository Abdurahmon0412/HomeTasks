namespace N63_FileStreamWebAPI.Models.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Password { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}