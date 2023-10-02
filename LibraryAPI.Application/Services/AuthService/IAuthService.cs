using Core.Utilities.Security.JWT;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.AuthService
{
    public interface IAuthService
    {
        public AccessToken CreateAccesToken(User user);
    }
}
