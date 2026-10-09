using Application.DTOs;

namespace Application.ServiceInterfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<BookDto> GetByIdAsync(int id);
    Task<BookDto> AddAsync(BookDto bookDto);
    Task UpdateAsync(int id, BookDto bookDto);
    Task RemoveAsync(int id);
}