using LibraryAPI.Domain.Entities.UserEntities;
namespace LibraryAPI.Application.Services.UserService
{
    public interface IUserReadService
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> GetUserByUserName(string userName);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByIdentityNumber(long identityNumber);
    }
}
