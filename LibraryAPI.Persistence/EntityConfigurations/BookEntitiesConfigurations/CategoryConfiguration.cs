
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.BookEntitiesConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CategoryName).IsRequired();

            builder.HasOne(p => p.Book)
                .WithOne(p => p.Category)
                .HasForeignKey<Book>(p => p.CategoryId);
        }
    }
}
