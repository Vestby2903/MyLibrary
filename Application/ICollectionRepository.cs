using Domain;

namespace Application;

public interface ICollectionRepository
{
    Task<IEnumerable<Collection>> GetAllAsync(CancellationToken cancellationToken = default);
    Task <Collection?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    void Add(Collection collection);
    void Remove(Collection collection);
}