using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.UserResorces;

namespace LibraryAPI.Application.Services.WriteServices.UserWriteServices
{
    public interface IUserWriteService
    {

        Task<User> AddUser(CreateUserDto user);
        Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto);
        Task<bool> DeleteUser(int id);
    }
}