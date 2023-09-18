using Core.Utilities.Security.JWT;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
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
            var res = _userOperationClaimReadRepository.GetAsync(x=>x.);
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }
    }
}
