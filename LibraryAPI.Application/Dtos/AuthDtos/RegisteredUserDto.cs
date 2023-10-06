using LibraryAPI.Application.Interfaces;
using LibraryAPI.Core.Utilities.Security.JWT;

namespace LibraryAPI.Application.Dtos.AuthDtos
{
    public class RegisteredUserDto : IDto
    {
        public AccessToken AccessToken { get; set; }

    }
}
