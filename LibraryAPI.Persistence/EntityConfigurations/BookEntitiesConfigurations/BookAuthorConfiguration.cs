
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.BookEntitiesConfigurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(k => new { k.BookId, k.AuthorId });
            builder.HasOne(p => p.Book).WithMany(p => p.Authors).HasForeignKey(p => p.BookId);
            builder.HasOne(p => p.Author).WithMany(p => p.Books).HasForeignKey(p => p.AuthorId);
        }
    }
}
