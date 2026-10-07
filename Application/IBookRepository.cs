using Domain;

namespace Application;

public interface IBookRepository
{
   Task<IEnumerable<Book>> GetAllAsync();
   Task <Book?> GetByIdAsync(int id);
   Task AddAsync(Book  book);
   void Update(Book book);
   void Remove(Book book);
}