
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Persistence.EntityConfigurations.UserEntitiesConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.HireDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.LeaveTime).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(1);
        }
    }
}
