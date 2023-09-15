using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IUserOperationClaimReadRepository userOperationClaimReadRepository, ITokenHelper tokenHelper)
        {
             _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _tokenHelper = tokenHelper;
        }
        public async Task<AccessToken> CreateAccesToken(User user)
        {
            List<OperationClaim> userOperationClaims = _userOperationClaimReadRepository.GetAll(u => u.UserId == user.Id,
                include: u => u.Include(u => u.OperationClaim)
                ).Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();            
            AccessToken accessToken = _tokenHelper.CreateToken(user , userOperationClaims);
            return accessToken;
        }
    }
}
