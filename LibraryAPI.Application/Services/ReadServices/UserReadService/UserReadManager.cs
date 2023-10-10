using AutoMapper;
using LibraryAPI.Application.Dtos.Views.UserViews;
using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Rules;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public class UserReadManager : IUserReadService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public UserReadManager(IUserReadRepository userReadRepository, UserBusinessRules userBusinessRules, IMapper mapper)
        {
            _mapper = mapper;
            _userReadRepository = userReadRepository;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<List<ResponseAllUserDto>> GetAllUser()
        {
            var result = await _userReadRepository.GetQuery().ToListAsync();
            List<ResponseAllUserDto> responseAllUserDto = _mapper.Map<List<ResponseAllUserDto>>(result);
            if (result == null) throw new BusinessException("Users not found.");
            return responseAllUserDto;
        }

        public async Task<List<ResponseAllUserWhereCustomerDto>> GetAllUserWhereCustomer()
        {
            string[] relations = { UserNavigations.Customer };
            var res = await _userReadRepository.GetQuery(includes: relations).ToListAsync();
            if (res == null) throw new BusinessException("Employe not found.");
            List<ResponseAllUserWhereCustomerDto> responseUserWhereCustomer = _mapper.Map<List<ResponseAllUserWhereCustomerDto>>(res);
            return responseUserWhereCustomer;
        }

        public async Task<List<ResponseAllUserWhereEmployeDto>> GetAllUserWhereEmployee()
        {
            string[] relations = {UserNavigations.Employee };
            var res = await _userReadRepository.GetQuery(includes: relations).ToListAsync();
            if (res == null) throw new BusinessException("Employe not found.");
            List<ResponseAllUserWhereEmployeDto> responseUserWhereEmploye = _mapper.Map<List<ResponseAllUserWhereEmployeDto>>(res);
            return responseUserWhereEmploye;
        }

        public async Task<ResponseAllUserDto> GetUserByEmail(string email)
        {
            var result = await _userReadRepository.GetAsync(x => x.Email == email);
            if (result == null) throw new BusinessException("User not found.");
            ResponseAllUserDto responseAllUserDto = _mapper.Map<ResponseAllUserDto>(result);
            return responseAllUserDto;
        }

        public async Task<ResponseAllUserDto> GetUserById(int id)
        {
            var result = await _userReadRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException("User not found.");
            ResponseAllUserDto responseAllUserDto = _mapper.Map<ResponseAllUserDto>(result);
            return responseAllUserDto;
        }

        public async Task<ResponseAllUserDto> GetUserByIdentityNumber(long identityNumber)
        {
            var result = await _userReadRepository.GetAsync(x => x.IdentityNumber == identityNumber);
            if (result == null) throw new BusinessException("User not found.");
            ResponseAllUserDto responseAllUserDto = _mapper.Map<ResponseAllUserDto>(result);
            return responseAllUserDto;
        }

        public async Task<ResponseAllUserDto> GetUserByUserName(string userName)
        {
            var result = await _userReadRepository.GetAsync(x => x.UserName == userName);
            if (result == null) throw new BusinessException("User not found.");
            ResponseAllUserDto responseAllUserDto = _mapper.Map<ResponseAllUserDto>(result);
            return responseAllUserDto;
        }
    }
}
