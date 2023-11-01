namespace Library.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = default!;
}