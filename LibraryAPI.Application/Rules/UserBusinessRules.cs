using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = await _userReadRepository.GetAsync(x=>x.Email == email, false);
            if (result != null) throw new BusinessException("User email already exist");
        }
        public async Task UserIdentityNumberAlreadyExist(long indentityNumber)
        {
            var result = await _userReadRepository.GetAsync(x=>x.IdentityNumber == indentityNumber, false);
            if (result != null) throw new BusinessException("User identity number already exist");
        }
        public async Task UserShouldExist(int userId)
        {
            var result = await _userReadRepository.GetAsync(x=>x.Id==userId,false);
            if (result == null) throw new BusinessException("User not found.");
        }
    }
}
