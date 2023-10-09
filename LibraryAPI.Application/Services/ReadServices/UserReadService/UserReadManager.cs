using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Rules;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public class UserReadManager : IUserReadService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public UserReadManager(IUserReadRepository userReadRepository, UserBusinessRules userBusinessRules)
        {
            _userReadRepository = userReadRepository;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<List<User>> GetAllUser()
        {
            var result = await _userReadRepository.GetQuery().ToListAsync();
            return result ?? throw new BusinessException("User not found.");
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _userReadRepository.GetAsync(x => x.Email == email);
            if (result == null) throw new BusinessException("User not found.");
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _userReadRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException("User not found.");
            return result;
        }

        public async Task<User> GetUserByIdentityNumber(long identityNumber)
        {
            var result = await _userReadRepository.GetAsync(x => x.IdentityNumber == identityNumber);
            if (result == null) throw new BusinessException("User not found.");
            return result;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var result = await _userReadRepository.GetAsync(x => x.UserName == userName);
            if (result == null) throw new BusinessException("User not found.");
            return result;
        }
    }
}
