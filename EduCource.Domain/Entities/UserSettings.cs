namespace EduCource.Domain.Entities;

public class UserSettings
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool IsDarkMood { get; set; }
}