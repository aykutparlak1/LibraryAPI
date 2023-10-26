using AutoMapper;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Aspects.Autofac.ValidationAspects;
using LibraryAPI.Core.Utilities.Security.Hashing;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.UserResorces;
using LibraryAPI.Dtos.Resources.Validations.UserValidations;
using LibraryAPI.Dtos.Views.UserViews;

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

        [ValidationAspect(typeof(CreateUserValidation))]
        public async Task<User> AddUser(CreateUserDto model)
        {
            await _userBusinessRules.UserIdentityNumberAlreadyExist(model.IdentityNumber);
            await _userBusinessRules.UserEmailAlreadyExist(model.Email);
            HashingHelper.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
           User user = _mapper.Map<User>(model);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = user.Email.ToLower();
            user.UserName = user.IdentityNumber.ToString();
            var addedUser = _userWriteRepository.Add(user);
            await _userWriteRepository.SaveAsync();
            return addedUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
           var result =  await _userBusinessRules.IfUserExistsReturnPublisherOrThrowException(id);
            bool res =_userWriteRepository.Remove(result);
            await _userWriteRepository.SaveAsync();
            return res;
        }

        [ValidationAspect(typeof(UpdateUserValidation))]
        public async Task<ResponseUserCommandDto> UpdateUser(UpdateUserDto updateUserDto)
        {
            await _userBusinessRules.UserShouldExist(updateUserDto.Id);
            updateUserDto.Email = updateUserDto.Email.ToLower();
           User mappedUser = _mapper.Map<User>(updateUserDto);
            var updatedUser = _userWriteRepository.Update(mappedUser);
            await _userWriteRepository.SaveAsync();
            ResponseUserCommandDto mappedUpdatedUserDto = _mapper.Map<ResponseUserCommandDto>(updatedUser);
            return mappedUpdatedUserDto;
        }
    }
}
