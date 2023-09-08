﻿using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.EntityConfigurations.UserEntitiesConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(k => new { k.UserId, k.OperationClaimId });
            builder.HasOne(p => p.User).WithMany(p => p.OperationClaims).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.OperationClaim).WithMany(p => p.Users).HasForeignKey(p => p.OperationClaimId);



        }
    }
}