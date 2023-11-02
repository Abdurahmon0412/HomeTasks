using EduCource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduCource.Persistance.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<CourseStudent> CourseStudents => Set<CourseStudent>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserSettings> UserSettingses => Set<UserSettings>();
}