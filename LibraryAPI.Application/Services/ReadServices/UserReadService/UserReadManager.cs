using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Rules;
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



        private static ResponseUserDto MapToResponseUserDto(User user)
        {
            return new ResponseUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                IdentityNumber = user.IdentityNumber,
                PhoneNumber = user.PhoneNumber,
                PhotoPath = user.PhotoPath,
                Status = user.Status,
                UserName = user.UserName,
                UserType = user.UserType,
            };
        }

        private static ResponseUserWhereCustomerDto MapToResponseUserWhereCustomerDto(User user)
        {
            return new ResponseUserWhereCustomerDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                UserName = user.UserName,
                IdentityNumber = user.IdentityNumber,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                SubEndDate = user.Customer.SubEndDate,
                SubStartDate = user.Customer.SubStartDate,
                PhotoPath = user.PhotoPath,
                IsSub = user.Customer.IsSub,
                
            };
        }

        private static ResponseUserWhereEmployeeDto MapToUserWhereEmployeeDto(User user)
        {
            return new ResponseUserWhereEmployeeDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                UserName = user.UserName,
                IdentityNumber = user.IdentityNumber,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                HireDate = user.Employee.HireDate,
                LeaveDate=user.Employee.LeaveDate,
                IsActive = user.Employee.IsActive,
                PhotoPath= user.PhotoPath,
                Title =user.Employee.Title,
            };
        }

        public async Task<List<ResponseUserDto>> GetAllUser()
        {
            var result = await _userReadRepository.GetQuery().Select(user=> MapToResponseUserDto(user)).ToListAsync();
            if (result == null) throw new BusinessException("Users not found.");
            return result;
        }

        public async Task<List<ResponseUserWhereCustomerDto>> GetAllUserWhereCustomer()
        {
            string[] relations = { UserNavigations.Customer };
            var res = await _userReadRepository.GetQuery(x=>x.UserType==0,includes: relations)
                .Select(user => MapToResponseUserWhereCustomerDto(user))
                .ToListAsync();
            if (res == null) throw new BusinessException("Customer not found.");
            return res;
        }

        public async Task<List<ResponseUserWhereEmployeeDto>> GetAllUserWhereEmployee()
        {
            string[] relations = {UserNavigations.Employee };


            var res = await _userReadRepository.GetQuery(x => x.UserType == 1,includes: relations)
                .Select(user => MapToUserWhereEmployeeDto(user))
                .ToListAsync();


            if (res == null) throw new BusinessException("Employe not found.");
            return res;
        }

        public async Task<ResponseUserDto> GetUserByEmail(string email)
        {
            var result = await _userReadRepository.GetQuery(x => x.Email == email)
                .Select(user => MapToResponseUserDto(user))
                .SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found Email:{email}.");
            return result;
        }

        public async Task<ResponseUserDto> GetUserById(int id)
        {
            var result = await _userReadRepository.GetQuery(x => x.Id == id)
                .Select(user => MapToResponseUserDto(user))
                .SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found.UserId:{id}");
            return result;
        }

        public async Task<ResponseUserDto> GetUserByIdentityNumber(long identityNumber)
        {
            var result = await _userReadRepository.GetQuery(x => x.IdentityNumber == identityNumber)
                .Select(user => MapToResponseUserDto(user)).SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found. IdentityNumber:{identityNumber}");
            return result;
        }

        public async Task<ResponseUserDto> GetUserByUserName(string userName)
        {
            var result = await _userReadRepository.GetQuery(x => x.UserName == userName)
                .Select(user => MapToResponseUserDto(user)).SingleOrDefaultAsync();
            if (result == null) throw new BusinessException($"User not found. UserName:{userName}");
            return result;
        }
    }
}
