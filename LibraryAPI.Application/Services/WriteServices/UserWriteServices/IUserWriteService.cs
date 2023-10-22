using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.UserResorces;

namespace LibraryAPI.Application.Services.WriteServices.UserWriteServices
{
    public interface IUserWriteService
    {

        Task<User> AddUser(CreateUserDto user);
        Task<User> UpdateUser(User user);
        Task<bool> RemoveUser(User user);
    }
}