using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.UserRepositories.EmployeeRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Views.EmployeeViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.EmployeeReadService
{
    public class EmployeeReadManager : IEmployeeReadService
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;

        public EmployeeReadManager(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;

        }

        private static ResponseEmployeeDto MapToResponseEmployeeDto(Employee employee)
        {
            return new ResponseEmployeeDto
            {

                UserName=employee.User.UserName,
                IdentityNumber=employee.User.IdentityNumber,
                FirstName=employee.User.FirstName,
                LastName=employee.User.LastName,
                Email=employee.User.Email,
                PhoneNumber=employee.User.PhoneNumber,
                BirthDate=employee.User.BirthDate,
                Status=employee.User.Status,
                HireDate=employee.HireDate,
                LeaveDate=employee.LeaveDate,
                PhotoPath=employee.User.PhotoPath,
                Title=employee.Title,
                IsActive=employee.IsActive,
                
        
            };
        }

        public async Task<List<ResponseEmployeeDto>> GetAllEmployee()
        {
            var res = await _employeeReadRepository.GetQuery(includes:EmployeeNavigations.User)
                .Select(employee=>MapToResponseEmployeeDto(employee)).ToListAsync();
            if (res.Count==0) throw new BusinessException("Employee not found.");
            return res;
        }

        public async Task<ResponseEmployeeDto> GetEmployeeById(int id)
        {
            var res = await _employeeReadRepository.GetQuery(x => x.Id == id, includes: EmployeeNavigations.User)
                .Select(employee => MapToResponseEmployeeDto(employee)).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException($"Employee not found id:{id}.");
            return res;
        }

        public async Task<ResponseEmployeeDto> GetEmployeeByIdentityNumber(long identityNumber)
        {
            var res = await _employeeReadRepository.GetQuery(x => x.User.IdentityNumber == identityNumber, includes: EmployeeNavigations.User)
                .Select(employee => MapToResponseEmployeeDto(employee)).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException($"Employee not found id:{identityNumber}.");

            return res;
        }

        public async Task<List<ResponseEmployeeDto>> GetEmployeeByIsActive(bool isActive)
        {
            var res = await _employeeReadRepository.GetQuery(filter:x=>x.IsActive==isActive,includes: EmployeeNavigations.User)
                    .Select(employee => MapToResponseEmployeeDto(employee)).ToListAsync();
            if (res.Count == 0) throw new BusinessException("Employee not found.");
            return res;
        }

        public async Task<List<ResponseEmployeeDto>> GetEmployeeByName(string name)
        {
            var res = await _employeeReadRepository.GetQuery(filter:x=>x.User.FirstName==name,includes: EmployeeNavigations.User)
                 .Select(employee => MapToResponseEmployeeDto(employee)).ToListAsync();
            if (res.Count == 0) throw new BusinessException("Employee not found.");
            return res;
        }
    }
}
