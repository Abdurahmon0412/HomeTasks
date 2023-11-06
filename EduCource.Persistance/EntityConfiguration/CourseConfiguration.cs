using EduCource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCource.Persistance.EntityConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasOne(course => course.Teacher)
            .WithMany(user => user.TeacherCourses)
                .HasForeignKey(course => course.TeacherId);
    }
}