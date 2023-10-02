using AutoMapper;
using Core.Utilities.Security.JWT;
using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.UserService;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisteredUserDto>
    {
        private readonly IUserWriteService _userWriteService;
        private readonly IAuthService _authservice;
        private readonly IMapper _mapper;
        private readonly IUserWriteRepository _userWriteRepository;
        public RegisterUserCommandHandler(IUserWriteService userWriteService, IUserWriteRepository userWriteRepository, IAuthService authService, IMapper mapper)
        {
            _userWriteRepository = userWriteRepository;
            _userWriteService = userWriteService;
            _authservice = authService;
            _mapper = mapper;
        }
        public async Task<RegisteredUserDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserDto crtUser = _mapper.Map<CreateUserDto>(request);
            User user = _userWriteService.CreateUser(crtUser);
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveAsync();
            AccessToken act =  _authservice.CreateAccesToken(user);
            RegisteredUserDto registeredDto = new()
            {
                AccessToken = act,
            };
            return registeredDto;
        }
    }
}
