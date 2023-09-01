
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.UserEntitiesConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.SubStartDate).IsRequired(false);
            builder.Property(p => p.SubEndDate).IsRequired(false);
            builder.Property(p => p.IsSub).IsRequired().HasDefaultValue(false);
        }
    }
}
