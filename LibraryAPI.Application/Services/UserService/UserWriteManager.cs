using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Rules;
using LibraryAPI.Core.Utilities.Security.Hashing;
using LibraryAPI.Domain.Entities.UserEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.UserService
{
    public class UserWriteManager : IUserWriteService
    {
        private IUserWriteRepository _userWriteRepository;
        private UserBusinessRules _userBusinessRules;

        public UserWriteManager(IUserWriteRepository userWriteRepository, UserBusinessRules userBusinessRules) 
        {
            _userWriteRepository = userWriteRepository;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<User> CreateUserAsync(CreateUserDto model)
        {
            await _userBusinessRules.UserEmailAlreadyExist(model.Email);
            await _userBusinessRules.UserIdentityNumberAlreadyExist(model.IdentityNumber);
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            User user = await _userWriteRepository.AddAsync(new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                IdentityNumber= model.IdentityNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                BirthDate = model.BirthDate,
            });
            return user;
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            await _userWriteRepository.Remove(user);
        }

        public async Task UpdateUserAsync(User user)
        { 
            await _userBusinessRules.UserShouldExist(user.Id);
            await _userWriteRepository.Update(user);
        }
    }
}
