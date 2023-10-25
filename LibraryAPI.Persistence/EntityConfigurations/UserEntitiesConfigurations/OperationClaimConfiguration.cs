using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.EntityConfigurations.UserEntitiesConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Name).IsRequired();


            builder.HasData( 
                new OperationClaim {Id = 1 , Name="Admin" },
                new OperationClaim { Id = 2, Name = "Moderator" },
                new OperationClaim { Id = 3, Name = "Member" }
                );
            
        }
    }
}
