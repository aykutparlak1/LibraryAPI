using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public class UserOperationClaimReadManager : IUserOperationClaimReadService
    {
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        public UserOperationClaimReadManager(IUserOperationClaimReadRepository userOperationClaimReadRepository)
        {
             _userOperationClaimReadRepository = userOperationClaimReadRepository;
        }
        public bool IsInRole(int id)
        {
            //  .GetQuery(x => x.UserId == UId, include: u => u.Include(u => u.OperationClaim))
            //.Select(u => new OperationClaim
            //{
            //    Name = u.OperationClaim.Name
            //}).AnyAsync(x => x.Name == _role);
            return true;
        }
    }
}
