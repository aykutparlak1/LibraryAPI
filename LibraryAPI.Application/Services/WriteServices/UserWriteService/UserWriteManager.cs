using LibraryAPI.Application.Dtos.UserDtos;
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



        public async Task<User> CreateUser(CreateUserDto model, CancellationToken cancellation)
        {
            await _userBusinessRules.UserIdentityNumberAlreadyExist(model.IdentityNumber);
            await _userBusinessRules.UserEmailAlreadyExist(model.Email);
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
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

            await _userWriteRepository.AddAsync(user, cancellation);
            await _userWriteRepository.SaveAsync(cancellation);
            return user;
        }

        public async Task<User> RemoveUser(User user, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            _userWriteRepository.Remove(user);
            await _userWriteRepository.SaveAsync(cancellationToken);
            return user;
        }

        public async Task<List<User>> RemoveUserRange(List<User> users, CancellationToken cancellationToken)
        {
            foreach (var user in users)
            {
               await _userBusinessRules.UserShouldExist(user.Id);
            }
            await _userWriteRepository.RemoveRange(users);
            await _userWriteRepository.SaveAsync(cancellationToken);
            return users;
        }

        public async Task<User> UpdateUser(User user, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserShouldExist(user.Id);
            await _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync(cancellationToken);
            return user;
        }


    }
}
