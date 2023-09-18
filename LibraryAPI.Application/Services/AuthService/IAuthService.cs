using Core.Utilities.Security.JWT;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccesToken(User user);
    }
}
