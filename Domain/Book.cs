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
}