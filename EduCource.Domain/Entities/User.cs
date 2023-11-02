#pragma warning disable CS8618

namespace EduCource.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public virtual ICollection<Course> TeacherCourses { get; set;} 

    public virtual ICollection<CourseStudent> CourseStudents { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
}