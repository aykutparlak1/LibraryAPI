using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.UserOperationClaimRepositories
{
    public class UserOperationClaimWriteRepository : WriteRepository<UserOperationClaim>, IUserOperationClaimWriteRepository
    {
        public UserOperationClaimWriteRepository(DbContext context) : base(context)
        {
        }
    }
}
