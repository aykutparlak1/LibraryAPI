
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.UserEntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.UserName)
                .IsRequired();
            builder.Property(p => p.FirstName)
                .IsRequired();
            builder.Property(p => p.LastName)
                .IsRequired();
            builder.Property(p => p.IdentityNumber)
                .IsRequired().HasMaxLength(11).IsFixedLength();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired(false).HasMaxLength(12);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired().HasColumnType("varbinary(500)");
            builder.Property(p => p.PasswordSalt).IsRequired().HasColumnType("varbinary(500)");
            builder.Property(p => p.UserType).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(true);




        }
    }
}
