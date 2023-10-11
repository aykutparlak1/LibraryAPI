using LibraryAPI.Dtos.Views.UserViews;

namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public interface IUserReadService
    {
        Task<List<ResponseUserDto>> GetAllUser();
        Task<ResponseUserDto> GetUserById(int id);  
        Task<ResponseUserDto> GetUserByUserName(string userName);
        Task<ResponseUserDto> GetUserByEmail(string email);
        Task<ResponseUserDto> GetUserByIdentityNumber(long identityNumber);
        Task<List<ResponseUserWhereEmployeeDto>> GetAllUserWhereEmployee();
        Task<List<ResponseUserWhereCustomerDto>> GetAllUserWhereCustomer();
        
    }
}
