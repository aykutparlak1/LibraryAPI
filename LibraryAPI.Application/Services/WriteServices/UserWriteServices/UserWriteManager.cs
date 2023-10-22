using AutoMapper;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Security.Hashing;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.UserResorces;

namespace LibraryAPI.Application.Services.WriteServices.UserWriteServices
{
    public class UserWriteManager : IUserWriteService
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;
        public UserWriteManager(IMapper mapper,IUserWriteRepository userWriteRepository, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _userWriteRepository = userWriteRepository;
            _userBusinessRules = userBusinessRules;
        }



        public async Task<User> AddUser(CreateUserDto model)
        {
            await _userBusinessRules.UserIdentityNumberAlreadyExist(model.IdentityNumber);
            await _userBusinessRules.UserEmailAlreadyExist(model.Email);
            HashingHelper.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = _mapper.Map<User>(model);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var addedUser = _userWriteRepository.Add(user);
            await _userWriteRepository.SaveAsync();
            return addedUser;
        }

        public async Task<bool> RemoveUser(User user)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            bool res =_userWriteRepository.Remove(user);
            await _userWriteRepository.SaveAsync();
            return res;
        }

        public async Task<User> UpdateUser(User user)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            var updatedUser = _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync();
            return updatedUser;
        }
    }
}
