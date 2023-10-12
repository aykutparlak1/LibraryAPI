using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepository;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.UserOperationClaimRepository
{
    public class UserOperationClaimReadRepository : ReadRepository<UserOperationClaim>, IUserOperationClaimReadRepository
    {
        public UserOperationClaimReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
