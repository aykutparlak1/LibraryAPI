using Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserReadRepository _userReadRepository;
        public UserBusinessRules(IUserReadRepository userReadRepository)
        {
             _userReadRepository = userReadRepository;
        }

        public void UserShouldExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("User not found.");
        }
        public async Task UserEmailAlreadyExist(string email)
        {
            var result = await _userReadRepository.GetAsync(x=>x.Email == email);
            if (result != null) throw new BusinessException("User email already exist");
        }
        public async Task UserIdentityNumberAlreadyExist(long identityNumber)
        {
            var result = await _userReadRepository.GetAsync(x=>x.IdentityNumber == identityNumber);
            if (result != null) throw new BusinessException("User identity number already exist");
        }
        public async Task UserShouldExist(int userId)
        {
            var result = await _userReadRepository.GetAsync(x=>x.Id==userId);
            if (result == null) throw new BusinessException("User not found.");
        }
    }
}
