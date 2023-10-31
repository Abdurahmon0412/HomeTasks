using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistance.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<VerificationCode> VerificationCodes => Set<VerificationCode>();


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<VerificationCode>().HasOne<User>();
    }
}