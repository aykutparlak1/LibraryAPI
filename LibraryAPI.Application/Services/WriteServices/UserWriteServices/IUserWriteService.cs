using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.UserResorces;
using LibraryAPI.Dtos.Views.UserViews;

namespace LibraryAPI.Application.Services.WriteServices.UserWriteServices
{
    public interface IUserWriteService
    {

        Task<ResponseUserCommandDto> AddUser(CreateUserDto user);
        Task<ResponseUserCommandDto> UpdateUser(UpdateUserDto updateUserDto);
        Task<bool> DeleteUser(int id);
    }
}