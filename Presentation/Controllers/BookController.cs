using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Repositories;
using Services;
using Services.Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IServiceBook _serviceBook;

    public BookController(ILogger<BookController> logger, IServiceBook serviceBook)
    {
        _logger = logger;
        _serviceBook = serviceBook;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> getById(string id)
    {
        try
        {
            return Ok(await _serviceBook.GetBookByIdAsync(id));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> get()
    {
        try
        {
            return Ok(await _serviceBook.GetAllBooksAsync());
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> post([FromBody] Book book)
    {
        try
        {
            return Ok(await _serviceBook.AddBookAsync(book));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> put([FromBody] Book book, string id)
    {
        try
        {
            return Ok(await _serviceBook.UpdateBookAsync(book, id));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> delete(string id)
    {
        try
        {
            return Ok(await _serviceBook.DeleteBookAsync(id));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}