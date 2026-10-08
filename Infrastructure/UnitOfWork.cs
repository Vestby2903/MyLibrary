using Application;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;

    public UnitOfWork(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}