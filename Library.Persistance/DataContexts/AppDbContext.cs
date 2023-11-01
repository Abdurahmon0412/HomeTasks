using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasOne(book => book.Author).WithMany();

    }
}
