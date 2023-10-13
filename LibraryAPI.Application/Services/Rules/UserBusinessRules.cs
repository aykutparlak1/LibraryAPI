using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;

namespace LibraryAPI.Application.Services.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserReadRepository _userReadRepository;
        public UserBusinessRules(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task UserEmailAlreadyExist(string email)
        {
            var result = await _userReadRepository.IsExist(x => x.Email == email);
            if (result) throw new BusinessException("User email already exist");
        }
        public async Task UserIdentityNumberAlreadyExist(long identityNumber)
        {
            var result = await _userReadRepository.IsExist(x => x.IdentityNumber == identityNumber);
            if (result) throw new BusinessException("User identity number already exist");
        }
        public async Task UserShouldExist(int userId)
        {
            var result = await _userReadRepository.IsExist(x => x.Id == userId);
            if (result) throw new BusinessException("User not found.");
        }
    }
}
