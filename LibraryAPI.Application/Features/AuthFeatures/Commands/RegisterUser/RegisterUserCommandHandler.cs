using AutoMapper;
using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.UserService;
using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisteredUserDto>
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
        public async Task<RegisteredUserDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserDto crtUser = _mapper.Map<CreateUserDto>(request);
            User user = await _userWriteService.CreateUserAsync(crtUser);
            AccessToken act = await _authservice.CreateAccesToken(user);
            RegisteredUserDto registeredDto = new()
            {
                AccessToken = act,
            };
            return registeredDto;
        }
    }
}
