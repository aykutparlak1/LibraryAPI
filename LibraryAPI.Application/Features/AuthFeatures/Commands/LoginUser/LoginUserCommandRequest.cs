using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginedUserDto>, IValidateRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
