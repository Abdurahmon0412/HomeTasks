#pragma warning disable CS8618

namespace EduCource.Domain.Entities;

public class Course
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public Guid TeacherId { get; set; }

    public virtual User Teacher { get; set; }

    public virtual ICollection<CourseStudent > CourseStudents { get; set; }
}
