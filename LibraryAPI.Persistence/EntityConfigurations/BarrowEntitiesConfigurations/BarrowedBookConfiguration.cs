using LibraryAPI.Domain.Entities.BarrowEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.BarrowEntitiesConfigurations
{
    public class BarrowedBookConfiguration : IEntityTypeConfiguration<BarrowedBook>
    {
        public void Configure(EntityTypeBuilder<BarrowedBook> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.BarrowStartDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.BarrowEndDate).IsRequired().HasComment("Enter the end date.");
            builder.Property(p => p.IsReturn).IsRequired().HasDefaultValue(false);


            builder.HasOne(p => p.User)
                .WithMany(p => p.BarrowedBooks)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Book)
                .WithMany(p => p.BarrowedBooks)
                .HasForeignKey(p => p.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
