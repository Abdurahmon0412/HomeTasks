using Library.Domain.Entities;
using Library.Persistance.DataContexts;
using LIbrary.Application.Foundations;
using System.Linq.Expressions;

namespace Library.Infrastructure.Foundations;

public class BookService : IEntityBaseService<Book>
{
    private readonly AppDbContext _appDbContext;

    public BookService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async ValueTask<Book> CreateAsync(Book book)
    {
        if (!IsValidBook(book))
            throw new ArgumentException("Book isn't valid");

        if (!IsUnique(book))
            throw new ArgumentException("this book already exists");
            
        await _appDbContext.Books.AddAsync(book);

        await _appDbContext.SaveChangesAsync();

        return book;
    }

    public IQueryable<Book> Get(Expression<Func<Book, bool>> predicate)
        => _appDbContext.Books.Where(predicate.Compile()).AsQueryable();


    public async ValueTask<Book> GetByIdAsync(Guid id)
        => await _appDbContext.Books.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "Book not found!");

    public async ValueTask<Book> UpdateAsync(Book book)
    {
        var foundBook = await GetByIdAsync(book.Id);

        foundBook.Author = book.Author;
        foundBook.AuthorId = book.AuthorId;
        foundBook.Description = book.Description;
        foundBook.Title = book.Title;

        _appDbContext.Books.Update(foundBook);

        return foundBook;
    }

    public async ValueTask<Book> DeleteAsync(Book book)
    {
        if(!book.IsDeleted)
            book.IsDeleted = true;

        _appDbContext.Remove(book);

        await _appDbContext.SaveChangesAsync();

        return book;
    }

    private bool IsValidBook(Book book)
    {
        if(book.Id == default 
            || string.IsNullOrWhiteSpace( book.Title) 
            || string.IsNullOrWhiteSpace( book.Description) 
            || book.Author == default
            || book.Author is null)
            return false;

        return true;
    }

    private bool IsUnique(Book book)
        => !_appDbContext.Books.Any(self => self.Id == book.Id || self.AuthorId.Equals(book.AuthorId));
}
