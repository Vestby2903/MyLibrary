using Domain;

namespace Application;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task <Book?> GetByIdAsync(int id);
    public Task AddAsync(Book  book);
    public Task UpdateAsync(Book book);
    public Task RemoveAsync(Book book);
}