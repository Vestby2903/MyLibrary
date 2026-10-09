using Application.DTOs;
using Domain;

namespace Application.Services;

public class BookService
{
    private readonly  IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();

        var bookDtos = books.Select(b => new BookDto(
            b.Id,
            b.Title,
            b.Author
        )).ToList();
        
        return bookDtos;
    }

    public async Task<BookDto> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Book with {id} not found");

        return new BookDto(book.Id, book.Title, book.Author);
    }

    public async Task<BookDto> AddAsync(BookDto bookDto)
    {
        var book = new Book(bookDto.Title, bookDto.Author);
        
        _bookRepository.Add(book);
        
        await _unitOfWork.SaveChangesAsync();

        return new BookDto(book.Id, book.Title, book.Author);
    }

    public async Task UpdateAsync(int id, BookDto bookDto)
    {
        var bookToBeUpdated =  await _bookRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Book with {id} not found");
        
        bookToBeUpdated.UpdateTitle(bookDto.Title);
        bookToBeUpdated.UpdateAuthor(bookDto.Author);
        
        _bookRepository.Update(bookToBeUpdated);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var bookToBeRemoved = await _bookRepository.GetByIdAsync(id)
                              ?? throw new KeyNotFoundException($"Book with {id} not found");
        
        _bookRepository.Remove(bookToBeRemoved);
        await _unitOfWork.SaveChangesAsync();
    }
}