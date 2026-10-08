using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;
    
    public BookRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.ToListAsync(cancellationToken);
    }

    public async Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.FindAsync([id], cancellationToken);
    }

    public void Add(Book book)
    {
        _dbContext.Books.Add(book);
    }

    public void Update(Book book)
    {
        _dbContext.Books.Update(book);
    }

    public void Remove(Book book)
    {
        _dbContext.Books.Remove(book);
    }
}