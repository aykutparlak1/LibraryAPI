using AutoMapper;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Application.Services.WriteServices.UserWriteServices;
using LibraryAPI.Core.Aspects.Autofac.Transaction;
using LibraryAPI.Core.Utilities.Security.Hashing;
using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Dtos.Resources.UserResorces;
using LibraryAPI.Dtos.Views.UserViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteService _userWriteService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        public AuthManager(IUserReadRepository userReadRepository, IUserWriteService userWriteService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _mapper= mapper;
           _tokenHelper = tokenHelper;
            _userReadRepository = userReadRepository;
            _userWriteService = userWriteService;
        }
        public async Task<AccessToken> Login(LoginUserDto loginUserDto)
        {
            loginUserDto.EmailOrUserName = loginUserDto.EmailOrUserName.ToLower();
            var user = await _userReadRepository.GetQuery(x => x.Email == loginUserDto.EmailOrUserName).Select(x=> new UserClaimsDto { Email=x.Email,FirstName=x.FirstName,Id=x.Id,LastName=x.LastName, PasswordHash = x.PasswordHash, PasswordSalt = x.PasswordSalt }).FirstOrDefaultAsync() 
                ?? await _userReadRepository.GetQuery(x => x.UserName == loginUserDto.EmailOrUserName).Select(x => new UserClaimsDto { Email = x.Email, FirstName = x.FirstName, Id = x.Id, LastName = x.LastName,PasswordHash=x.PasswordHash,PasswordSalt=x.PasswordSalt }).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Core.CrossCuttingConcerns.Exceptions.AuthenticationException("Giriş Başarısız. Kullanıcı adı - email veya şifre yanlış.");
            }
            if (!HashingHelper.VerifyPasswordHash(loginUserDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Core.CrossCuttingConcerns.Exceptions.AuthenticationException("Giriş Başarısız. Kullanıcı adı - email veya şifre yanlış.");
            }
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }
        [TransactionAspect]
        public async Task<AccessToken> Register(CreateUserDto createUserDto)
        {
            var createUser = await _userWriteService.AddUser(createUserDto);
            UserClaimsDto userClaims = _mapper.Map<UserClaimsDto>(createUser);
            AccessToken accessToken = _tokenHelper.CreateToken(userClaims);
            return accessToken;
        }
    }
}
