#pragma warning disable CS8618

namespace EduCource.Domain.Entities;

public class CourseStudent
{
    public Guid Id { get; set; }

    public Guid CourcseId { get; set; }

    public Guid StudentId { get; set; }

    public virtual Course Course { get; set; }

    public virtual User Student { get; set; }
}