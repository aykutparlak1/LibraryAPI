
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.BookEntitiesConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.PublisherId).IsRequired();
            builder.Property(p => p.NumberOfPages).IsRequired();
            builder.Property(p => p.Location).HasComment("Shelf Number");
            builder.HasOne(p => p.Publisher).WithMany(p => p.Books).HasForeignKey(p => p.PublisherId);
            
        }
    }
}
