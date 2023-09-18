using Core.Utilities.Security.JWT;
using LibraryAPI.Application.Interfaces;

namespace LibraryAPI.Application.Dtos.AuthDtos
{
    public class LoginedUserDto : IDto
    {
        public AccessToken AccessToken { get; set; }
    }
}
