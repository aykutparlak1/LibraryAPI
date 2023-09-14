using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Rules;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.UserService
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
            var result = await _userReadRepository.GetAll().ToListAsync();
            _userBusinessRules.UserShouldExistWhenRequested(result[0]);
            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _userReadRepository.GetAsync(x=>x.Email == email);
            _userBusinessRules.UserShouldExistWhenRequested(result);
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _userReadRepository.GetAsync(x=>x.Id == id);
            _userBusinessRules.UserShouldExistWhenRequested(result);
            return result;
        }

        public async Task<User> GetUserByIdentityNumber(long identityNumber)
        {
            var result = await _userReadRepository.GetAsync(x=>x.IdentityNumber == identityNumber);
            _userBusinessRules.UserShouldExistWhenRequested(result);
            return result;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var result = await _userReadRepository.GetAsync(x=>x.UserName == userName);
            _userBusinessRules.UserShouldExistWhenRequested(result);
            return result;
        }
    }
}
