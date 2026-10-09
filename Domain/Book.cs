namespace Domain;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    // EF Core needs an empty object before populating it 
    private Book()
    {
        Title  = null!;
        Author = null!;
    }

    public void UpdateTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Title cannot be null or empty",  nameof(title));
        }

        // Updated is equal to existing?
        // Don't mark as updated
        if (Title == title)
        {
            return;
        }

        Title = title;
    }
    
    public void UpdateAuthor(string author)
    {
        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentException("Author cannot be null or empty",  nameof(author));
        }

        // Updated is equal to existing?
        // Don't mark as updated
        if (Author == author)
        {
            return;
        }

        Author = author;
    }
}