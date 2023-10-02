using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Services.AuthService;
using MediatR;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginedUserDto>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IUserReadRepository userReadRepository, IAuthService authService)
        {
            _userReadRepository = userReadRepository;
            _authService = authService;

        }
        public async Task<LoginedUserDto> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetAsync(x=>x.Email == request.Email);
            if ( user == null) { throw new AuthorizationException("Giriş Başarısız."); }
            bool checkPassword = HashingHelper.VerifyPasswordHash(request.Password , user.PasswordHash , user.PasswordSalt);
            if (!checkPassword) { throw new AuthorizationException("Giriş Başarısız."); }
            AccessToken acst =  _authService.CreateAccesToken(user);
            LoginedUserDto loginedUserDto = new()
            {
                AccessToken = acst,
            };
            return loginedUserDto;
        }
    }
}
