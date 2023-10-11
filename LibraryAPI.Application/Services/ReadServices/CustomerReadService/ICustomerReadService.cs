using LibraryAPI.Dtos.Views.CustomerViews;

namespace LibraryAPI.Application.Services.ReadServices.CustomerReadService
{
    public interface ICustomerReadService
    {
        Task<List<ResponseCustomerDto>> GetAllCustomer();
        Task<ResponseCustomerDto> GetCustomerById(int id);
        Task<List<ResponseCustomerDto>> GetCustomerByName(string name);
        Task<List<ResponseCustomerDto>> GetCustomerIsSub(bool isSub);
        Task<ResponseCustomerDto> GetCustomerByUserId(int id);
        Task<ResponseCustomerDto> GetCustomerByIdentityNumber(long identityNumber);
    }
}
