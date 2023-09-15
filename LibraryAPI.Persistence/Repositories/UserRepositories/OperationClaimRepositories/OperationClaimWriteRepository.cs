using LibraryAPI.Application.Repositories.UserRepositories.OperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.OperationClaimRepositories
{
    public class OperationClaimWriteRepository : WriteRepository<OperationClaim>, IOperationClaimWriteRepository
    {
        public OperationClaimWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
