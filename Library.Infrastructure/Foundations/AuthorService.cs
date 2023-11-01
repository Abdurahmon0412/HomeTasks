using Library.Domain.Entities;
using Library.Persistance.DataContexts;
using LIbrary.Application.Foundations;
using System.Linq.Expressions;

namespace Library.Infrastructure.Foundations;

public class AuthorService : IEntityBaseService<Author>
{
    private readonly AppDbContext _appDbContext;

    public AuthorService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async ValueTask<Author> CreateAsync(Author author)
    {
        if (!IsValidAuthor(author))
            throw new ArgumentException("Author isn't valid");

        if (!IsUnique(author))
            throw new ArgumentException("this author already exists");

        await _appDbContext.Authors.AddAsync(author);

        await _appDbContext.SaveChangesAsync();

        return author;
    }

    public IQueryable<Author> Get(Expression<Func<Author, bool>> predicate)
         => _appDbContext.Authors.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Author> GetByIdAsync(Guid id)
        => await _appDbContext.Authors.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "Book not found!");

    public async ValueTask<Author> UpdateAsync(Author author)
    {
        var foundAuthor = await GetByIdAsync(author.Id);

        foundAuthor.FullName = author.FullName;

        _appDbContext.Authors.Update(foundAuthor);

        _appDbContext.SaveChanges();

        return author;
    }

    public async ValueTask<Author> DeleteAsync(Author author)
    {
        _appDbContext.Remove(author);

        await _appDbContext.SaveChangesAsync();

        return author;
    }

    private bool IsValidAuthor(Author author)
    {
        if(author.FullName is null )
            return false;
        return true;
    }

    public bool IsUnique(Author author)
        => !_appDbContext.Authors.Any(self => self.Id == author.Id);

}
