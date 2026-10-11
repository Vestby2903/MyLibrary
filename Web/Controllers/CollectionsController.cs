using Application.DTOs;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectionsController : ControllerBase
{
    private readonly ICollectionService _collectionService;
    
    public CollectionsController(ICollectionService collectionService)
    {
        _collectionService = collectionService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var collections = await _collectionService.GetAllAsync();
        return Ok(collections);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var collection = await _collectionService.GetByIdAsync(id);
        return Ok(collection);
    }

    [HttpPost]
    public async Task<IActionResult> Add()
    {
        var createdCollection = await _collectionService.AddAsync();
        
       return CreatedAtAction(nameof(GetById),  new { id = createdCollection.Id }, createdCollection); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _collectionService.RemoveAsync(id);
        
        return NoContent();
    }

    [HttpPost("{collectionId}/books/{bookId}")]
    public async Task<IActionResult> AddBook(int collectionId, int bookId)
    {
        await _collectionService.AddBookAsync(collectionId, bookId);
        return NoContent();
    }

    [HttpDelete("{collectionId}/books/{bookId}")]
    public async Task<IActionResult> RemoveBook(int collectionId, int bookId)
    {
        await _collectionService.RemoveBookAsync(collectionId, bookId);
        
        return NoContent();
    }
}