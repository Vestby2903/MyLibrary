using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    // Represents database tables
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Collection> Collections => Set<Collection>();
}