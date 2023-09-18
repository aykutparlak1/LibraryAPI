using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.UserService;
using MediatR;
using System.Security.Authentication;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginedUserDto>
    {
        private readonly IUserReadService _userReadService;
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IUserReadService userReadService, IAuthService authService)
        {
            _userReadService = userReadService;
            _authService = authService;

        }
        public async Task<LoginedUserDto> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadService.GetUserByEmail(request.Email);
            if ( user == null) { throw new AuthenticationException("Giriş Başarısız."); }
            bool checkPassword = HashingHelper.VerifyPasswordHash(request.Password , user.PasswordHash , user.PasswordSalt);
            if (!checkPassword) { throw new AuthenticationException("Giriş Başarısız."); }
            AccessToken acst = await _authService.CreateAccesToken(user);
            LoginedUserDto loginedUserDto = new()
            {
                AccessToken = acst,
            };
            return loginedUserDto;
        }
    }
}
