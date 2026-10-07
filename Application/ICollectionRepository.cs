using Domain;

namespace Application;

public interface ICollectionRepository
{
    Task<IEnumerable<Collection>> GetAllAsync();
    Task <Collection?> GetByIdAsync(int id);
    Task AddAsync(Collection collection);
    void Update(Collection collection);
    void Remove(Collection collection);
}