using LibraryAPI.Application.Dtos.AuthDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserCommanRequest : IRequest<RegisteredUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long IdentityNumber { get; set; }

        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}
