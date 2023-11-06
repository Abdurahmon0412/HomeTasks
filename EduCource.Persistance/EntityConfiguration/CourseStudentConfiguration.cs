using EduCource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCource.Persistance.EntityConfiguration;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
        builder.HasKey(cs => new {cs.CourcseId, cs.StudentId});

        builder.HasOne(cs => cs.Course).WithMany(c => c.CourseStudents).HasForeignKey(cs => cs.CourcseId);

        builder.HasOne(cs => cs.Student).WithMany(s => s.CourseStudents).HasForeignKey(cs => cs.StudentId);
    }
}