namespace HomeTask62_Tokens.Models.Dtos;

public class RegistrationDetails
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }

    public string EmailAddress { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}