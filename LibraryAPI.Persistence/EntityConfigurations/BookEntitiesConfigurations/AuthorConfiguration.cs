using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.BookEntitiesConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.AuthorLastName).IsRequired();
            builder.Property(p => p.AuthorFirstName).IsRequired();

        }
    }
}
