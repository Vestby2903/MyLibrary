using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence;

public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> builder)
    {
        // Primary key
        builder.HasKey(c => c.Id);

        // Defines a "one-to-many" relationship with 'Book'
        // When a 'Collection' is deleted all 'Book' within it are also deleted
        builder.HasMany(c => c.Books)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}