using Application.DTOs;

namespace Application.ServiceInterfaces;

public interface ICollectionService
{
    Task<IEnumerable<CollectionDto>> GetAllAsync();
    Task<CollectionDto> GetByIdAsync(int id);
    Task<CollectionDto> AddAsync();
    Task RemoveAsync(int id);
    Task AddBookAsync(int collectionId, int bookId);
    Task RemoveBookAsync(int collectionId, int bookId);
}