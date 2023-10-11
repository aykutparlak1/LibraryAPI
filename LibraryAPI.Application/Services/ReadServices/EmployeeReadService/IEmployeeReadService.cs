

using LibraryAPI.Dtos.Views.EmployeeViews;

namespace LibraryAPI.Application.Services.ReadServices.EmployeeReadService
{
    public interface IEmployeeReadService
    {
        Task<List<ResponseEmployeeDto>> GetAllEmployee();

        Task<ResponseEmployeeDto> GetEmployeeById(int id);

        Task<List<ResponseEmployeeDto>> GetEmployeeByName(string name);

        Task<ResponseEmployeeDto> GetEmployeeByIdentityNumber(long identityNumber);
        Task<List<ResponseEmployeeDto>> GetEmployeeByIsActive(bool isActive);
    }
}
