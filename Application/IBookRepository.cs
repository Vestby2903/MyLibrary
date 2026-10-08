using Domain;

namespace Application;

public interface IBookRepository
{
   Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default);
   Task <Book?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
   void Add(Book  book);
   void Update(Book book);
   void Remove(Book book);
}