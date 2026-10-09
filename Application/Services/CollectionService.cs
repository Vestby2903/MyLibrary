using Application.DTOs;
using Application.ServiceInterfaces;
using Domain;

namespace Application.Services;

public class CollectionService : ICollectionService
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CollectionService(
        ICollectionRepository collectionRepository, 
        IBookRepository bookRepository, 
        IUnitOfWork unitOfWork)
    {
        _collectionRepository = collectionRepository;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CollectionDto>> GetAllAsync()
    {
        var collections = await _collectionRepository.GetAllAsync();

        return collections.Select(c => new CollectionDto(
            c.Id,
            c.Books.Select(b => new BookDto(
                b.Id,
                b.Title,
                b.Author))
                .ToList()
            ));
    }

    public async Task<CollectionDto> GetByIdAsync(int id)
    {
        var collection = await _collectionRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Collection with {id} not found");

        return new CollectionDto
            (
                collection.Id,
                collection.Books.Select(b => new BookDto
                    (
                        b.Id,
                        b.Title,
                        b.Author
                    ))
                    .ToList()
            );
    }

    public async Task<CollectionDto> AddAsync()
    {
        var collection = new Collection();
        
        _collectionRepository.Add(collection);
        await _unitOfWork.SaveChangesAsync();

        return new CollectionDto(
            collection.Id,
            []
        );
    }
    
    public async Task RemoveAsync(int id)
    {
        var collectionToBeRemoved =  await _collectionRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Collection with {id} not found");
        
        _collectionRepository.Remove(collectionToBeRemoved);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddBookAsync(int collectionId, int bookId)
    {
        var collection = await _collectionRepository.GetByIdAsync(collectionId)
            ?? throw new KeyNotFoundException($"Collection with {collectionId} not found");
        
        var book = await _bookRepository.GetByIdAsync(bookId)
            ?? throw new KeyNotFoundException($"Book with {bookId} not found");
        
        collection.AddBook(book);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveBookAsync(int collectionId, int bookId)
    {
        var collection = await _collectionRepository.GetByIdAsync(collectionId)
            ?? throw new KeyNotFoundException($"Collection with {collectionId} not found");
        
       var book = collection.Books.FirstOrDefault(b => b.Id == bookId)
           ?? throw new KeyNotFoundException($"Book with {bookId} not found");
        
        collection.RemoveBook(book);
        
        await _unitOfWork.SaveChangesAsync();
    }
}
