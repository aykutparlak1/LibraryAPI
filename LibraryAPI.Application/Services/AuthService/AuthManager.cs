using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Task<AccessToken> CreateAccesToken(User user)
        {
            IList<UserOperationClaim> userOperationClaims = _userOperationClaimReadRepository.GetAll(u=>u.UserId==user.Id, 
                include:u=>u.Include(u=>u.OperationClaim)
                ).ToList();
            //AccessToken accessToken = _tokenHelper.CreateToken(user , userOperationClaims);
            throw new NotImplementedException();
        }
    }
}
