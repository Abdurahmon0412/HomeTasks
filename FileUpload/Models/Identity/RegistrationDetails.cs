namespace FileUpload.Models.Identity;

public record RegistrationDetails (string FirstName, string LastName , 
    string   UserName, string Email, string Password);