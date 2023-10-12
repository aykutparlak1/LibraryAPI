using LibraryAPI.Application.Repositories;
using LibraryAPI.Application.Repositories.UserRepositories.OperationClaimRepository;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.OperationClaimRepository
{
    public class OperationClaimReadRepository : ReadRepository<OperationClaim>, IOperationClaimReadRepository
    {
        public OperationClaimReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
