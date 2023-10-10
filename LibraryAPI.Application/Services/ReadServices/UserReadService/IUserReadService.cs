using LibraryAPI.Application.Dtos.Views.UserViews;
namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public interface IUserReadService
    {
        Task<List<ResponseAllUserDto>> GetAllUser();
        Task<ResponseAllUserDto> GetUserById(int id);  
        Task<ResponseAllUserDto> GetUserByUserName(string userName);
        Task<ResponseAllUserDto> GetUserByEmail(string email);
        Task<ResponseAllUserDto> GetUserByIdentityNumber(long identityNumber);
        Task<List<ResponseAllUserWhereEmployeDto>> GetAllUserWhereEmployee();
        Task<List<ResponseAllUserWhereCustomerDto>> GetAllUserWhereCustomer();
        
    }
}
