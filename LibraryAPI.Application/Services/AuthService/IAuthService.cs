using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Dtos.Resources.UserResorces;

namespace LibraryAPI.Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<AccessToken> Register(CreateUserDto createUserDto);
        Task<AccessToken> Login(LoginUserDto loginUserDto);
    }
}
