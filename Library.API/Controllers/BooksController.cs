using Library.Domain.Entities;
using Library.Infrastructure.Foundations;
using LIbrary.Application.Foundations;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

public class BooksController : ControllerBase
{
    private readonly IEntityBaseService<Book> _bookService;

	public BooksController(IEntityBaseService<Book> bookService) => _bookService = bookService;

    [HttpPost("books")]
    public async ValueTask<IActionResult> AddBook([FromBody] Book book)
        => Ok(await _bookService.CreateAsync(book));

    [HttpGet("books")]
    public IActionResult GetBooks()
        => Ok(_bookService.Get(book => true));

    [HttpGet("books/{bookId:guid}")]
    public async ValueTask<IActionResult> GetBooksById(Guid bookId)
        => Ok(await _bookService.GetByIdAsync(bookId));

    [HttpPut("books/update")]
    public async ValueTask<IActionResult> UpdateBooks([FromBody] Book book)
        => Ok(await _bookService.UpdateAsync(book));

    [HttpDelete("books/delete")]
    public async ValueTask<IActionResult> DeleteBoos([FromBody] Book book)
        => Ok(await _bookService.DeleteAsync(book));
}