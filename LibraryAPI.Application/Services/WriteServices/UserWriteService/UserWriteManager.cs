using AutoMapper;
using LibraryAPI.Application.Dtos.Resources.UserResorces;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Rules;
using LibraryAPI.Core.Utilities.Security.Hashing;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.WriteServices.UserWriteService
{
    public class UserWriteManager : IUserWriteService
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly UserBusinessRules _userBusinessRules;
        public UserWriteManager(IUserWriteRepository userWriteRepository, UserBusinessRules userBusinessRules)
        {

            _userWriteRepository = userWriteRepository;
            _userBusinessRules = userBusinessRules;
        }



        public async Task<User> CreateUser(CreateUserDto model)
        {
            await _userBusinessRules.UserIdentityNumberAlreadyExist(model.IdentityNumber);
            await _userBusinessRules.UserEmailAlreadyExist(model.Email);
            HashingHelper.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                IdentityNumber = model.IdentityNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                BirthDate = model.BirthDate,
            };
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveAsync();
            return user;
        }

        public async Task<User> RemoveUser(User user)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            _userWriteRepository.Remove(user);
            await _userWriteRepository.SaveAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            await _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync();
            return user;
        }
    }
}
