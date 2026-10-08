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

    public async Task<IEnumerable<Collection>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Collections.ToListAsync(cancellationToken);
    }

    public async Task<Collection?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Collections.FindAsync([id], cancellationToken);
    }

    public void Add(Collection collection)
    {
        _dbContext.Collections.Add(collection);
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