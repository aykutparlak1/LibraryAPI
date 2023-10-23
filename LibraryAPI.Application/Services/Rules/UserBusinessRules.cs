using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User> IfUserExistsReturnPublisherOrThrowException(int id)
        {
            User isExists = await _userReadRepository.GetQuery(x => x.Id == id).SingleOrDefaultAsync();
            if (isExists == null) { throw new BusinessException("User Not Found"); }
            return isExists;
        }
    }
}
