namespace Library.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public Guid AuthorId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Author Author { get; set; } = default!;
}