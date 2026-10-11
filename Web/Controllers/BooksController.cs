using Application.DTOs;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _bookService.GetByIdAsync(id);

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] BookDto bookDto)
    {
        var bookId = await _bookService.AddAsync(bookDto);
        return CreatedAtAction(nameof(GetById), new { id = bookId.Id }, bookId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BookDto bookDto)
    {
        await _bookService.UpdateAsync(id, bookDto);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookService.RemoveAsync(id);
        
        return NoContent();
    }
}