using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Views.UserViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public class UserReadManager : IUserReadService
    {
        private readonly IUserReadRepository _userReadRepository;

        public UserReadManager(IUserReadRepository userReadRepository, UserBusinessRules userBusinessRules)
        {
              _userReadRepository = userReadRepository;
        }


        public async Task<List<ResponseUserDto>> GetAllUser()
        {
            var result = await _userReadRepository.GetQuery().Select(user=> new ResponseUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                IdentityNumber = user.IdentityNumber,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                UserName = user.UserName,
            }).ToListAsync();
            if (result == null) throw new BusinessException("Users not found.");
            return result;
        }


        public async Task<ResponseUserDto> GetUserByEmail(string email)
        {
            var result = await _userReadRepository.GetQuery(x => x.Email == email)
                .Select(user => new ResponseUserDto
                {
                    Id=user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    IdentityNumber = user.IdentityNumber,
                    PhoneNumber = user.PhoneNumber,
                    Status = user.Status,
                    UserName = user.UserName,
                })
                .SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found Email:{email}.");
            return result;
        }

        public async Task<ResponseUserDto> GetUserById(int id)
        {
            var result = await _userReadRepository.GetQuery(x => x.Id == id)
                .Select(user => new ResponseUserDto
                {

                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    IdentityNumber = user.IdentityNumber,
                    PhoneNumber = user.PhoneNumber,
                    Status = user.Status,
                    UserName = user.UserName,
                })
                .SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found.UserId:{id}");
            return result;
        }

        public async Task<ResponseUserDto> GetUserByIdentityNumber(long identityNumber)
        {
            var result = await _userReadRepository.GetQuery(x => x.IdentityNumber == identityNumber)
                .Select(user => new ResponseUserDto
                {

                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    IdentityNumber = user.IdentityNumber,
                    PhoneNumber = user.PhoneNumber,
                    Status = user.Status,
                    UserName = user.UserName,
                }).SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found. IdentityNumber:{identityNumber}");
            return result;
        }

        public async Task<ResponseUserDto> GetUserByUserName(string userName)
        {
            var result = await _userReadRepository.GetQuery(x => x.UserName == userName)
                .Select(user => new ResponseUserDto
                {
                    
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    IdentityNumber = user.IdentityNumber,
                    PhoneNumber = user.PhoneNumber,
                    Status = user.Status,
                    UserName = user.UserName,
                } ).SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found. UserName:{userName}");
            return result;
        }
    }
}
