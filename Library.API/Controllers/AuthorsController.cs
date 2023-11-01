using Library.Domain.Entities;
using LIbrary.Application.Foundations;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IEntityBaseService<Author> _authorService;

    public AuthorsController(IEntityBaseService<Author> authorService) => _authorService = authorService;

    [HttpPost("authors")]
    public async ValueTask<IActionResult> AddAuthors([FromBody] Author author) 
        => Ok(await _authorService.CreateAsync(author));

    [HttpGet("authors")]
    public IActionResult GetAuthors()
        => Ok(_authorService.Get(author => true));

    [HttpGet("authors/{authorsId:guid}")]
    public async ValueTask<IActionResult> GetAuthorsById(Guid authorsId)
        => Ok(await _authorService.GetByIdAsync(authorsId));

    [HttpPut("authors/update")]
    public async ValueTask<IActionResult> UpdateAuthors([FromBody] Author author)
        => Ok(await _authorService.UpdateAsync(author));

    [HttpDelete("authors/delete")]
    public async ValueTask<IActionResult> DeleteAuthors([FromBody] Author author)
        => Ok(await _authorService.DeleteAsync(author));
}