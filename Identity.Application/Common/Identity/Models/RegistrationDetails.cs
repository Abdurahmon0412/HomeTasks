namespace Identity.Application.Common.Identity.Models;

public class RegistrationDetails
{
    public string UserName { get; set; } = string.Empty;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}