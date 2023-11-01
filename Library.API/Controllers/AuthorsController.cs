using Library.Domain.Entities;
using LIbrary.Application.Foundations;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IEntityBaseService<Book> _bookService;
    private readonly IEntityBaseService<Author> _authorService;

    public AuthorsController(IEntityBaseService<Book> baseService,
        IEntityBaseService<Author> authorService)
    {
        _authorService = authorService;
        _bookService = baseService;
    }

    //[HttpPost("authors")]

}
