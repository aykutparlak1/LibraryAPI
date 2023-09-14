using AutoMapper;
using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.UserService;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommanRequest, RegisteredUserDto>
    {
        private readonly IUserWriteService _userWriteService;
        private readonly IAuthService _authservice;
        private readonly IMapper _mapper;
        public RegisterUserCommandHandler(IUserWriteService userWriteService,IAuthService authService, IMapper mapper)
        {
            _userWriteService = userWriteService;
            _authservice = authService;
            _mapper = mapper;
        }
        public async Task<RegisteredUserDto> Handle(RegisterUserCommanRequest request, CancellationToken cancellationToken)
        {
            CreateUserDto crtUser = _mapper.Map<CreateUserDto>(request);
            User user = await _userWriteService.CreateUserAsync(crtUser);
            await _authservice.CreateAccesToken(user);
            throw new NotImplementedException();
        }
    }
}
