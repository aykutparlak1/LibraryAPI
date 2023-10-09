using LibraryAPI.Application.Dtos.Resources.UserResorces;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.WriteServices.UserWriteService
{
    public interface IUserWriteService
    {

        Task<User> CreateUser(CreateUserDto user);
        Task<User> UpdateUser(User user);
        Task<User> RemoveUser(User user);
    }
}
