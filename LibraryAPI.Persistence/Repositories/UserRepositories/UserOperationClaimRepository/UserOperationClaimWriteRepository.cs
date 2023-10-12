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
    public class UserOperationClaimWriteRepository : WriteRepository<UserOperationClaim>, IUserOperationClaimWriteRepository
    {
        public UserOperationClaimWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
