using LibraryAPI.Application.Repositories.UserRepositories.OperationClaimRepository;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.OperationClaimRepository
{
    public class OperationClaimReadRepository : ReadRepository<OperationClaim>, IOperationClaimReadRepository
    {
        public OperationClaimReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
