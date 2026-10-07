using Domain;

namespace Application;

public interface ICollectionRepository
{
    Task<IEnumerable<Collection>> GetAllAsync();
    Task <Collection?> GetByIdAsync(int id);
    Task AddAsync(Collection collection);
    Task UpdateAsync(Collection collection);
    Task RemoveAsync(Collection collection);
}