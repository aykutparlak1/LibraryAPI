using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Services.UserService
{
    public interface IUserWriteService
    {

        Task<User> CreateUser(CreateUserDto user, CancellationToken cancellation);
        Task<User> UpdateUser(User user, CancellationToken cancellationToken);
        Task<User> RemoveUser(User user, CancellationToken cancellationToken);
        Task<List<User>> RemoveUserRange(List<User> users, CancellationToken cancellationToken);
    }
}
