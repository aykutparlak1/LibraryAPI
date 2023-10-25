using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepository;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.UserOperationClaimRepository
{
    public class UserOperationClaimWriteRepository : WriteRepository<UserOperationClaim>, IUserOperationClaimWriteRepository
    {
        public UserOperationClaimWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
