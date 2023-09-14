﻿using LibraryAPI.Application.Repositories;
using LibraryAPI.Application.Repositories.UserRepositories.OperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.OperationClaimRepositories
{
    public class OperationClaimReadRepository : ReadRepository<OperationClaim>, IOperationClaimReadRepository
    {
        public OperationClaimReadRepository(DbContext context) : base(context)
        {
        }
    }
}
