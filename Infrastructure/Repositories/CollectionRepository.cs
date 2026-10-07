using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CollectionRepository : ICollectionRepository
{
    private readonly LibraryDbContext _dbContext;

    public CollectionRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Collection>> GetAllAsync()
    {
        return await _dbContext.Collections.ToListAsync();
    }

    public async Task<Collection?> GetByIdAsync(int id)
    {
        return await _dbContext.Collections.FindAsync(id);
    }

    public async Task AddAsync(Collection collection)
    {
        await _dbContext.Collections.AddAsync(collection);
    }

    public void Update(Collection collection)
    {
        _dbContext.Collections.Update(collection);
    }

    public void Remove(Collection collection)
    {
        _dbContext.Collections.Remove(collection);
    }
}