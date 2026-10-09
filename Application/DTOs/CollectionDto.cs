namespace Application.DTOs;

public record CollectionDto(int Id, IReadOnlyCollection<BookDto> Books);