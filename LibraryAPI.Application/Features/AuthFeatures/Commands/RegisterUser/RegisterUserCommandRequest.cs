using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser
{

    public class RegisterUserCommandRequest : IRequest<RegisteredUserDto>, IValidateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}
