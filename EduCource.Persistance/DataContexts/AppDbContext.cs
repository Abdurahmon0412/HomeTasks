using EduCource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduCource.Persistance.DataContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users => Set<User>();

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<CourseStudent> CourseStudents => Set<CourseStudent>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<UserSettings> UserSettingses => Set<UserSettings>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}