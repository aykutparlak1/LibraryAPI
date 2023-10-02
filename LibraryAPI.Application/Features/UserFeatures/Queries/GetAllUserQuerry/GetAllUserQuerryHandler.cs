using AutoMapper;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Services.UserService;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;

namespace LibraryAPI.Application.Features.UserFeatures.Queries.GetAllUserQuerry
{
    public class GetAllUserQuerryHandler : IRequestHandler<GetAllUserQuerryRequest, ReadUserDto>
    {
        private readonly IUserReadService _userReadService;
        private readonly IMapper _mapper;
        public GetAllUserQuerryHandler(IUserReadService userReadService, IMapper mapper)
        {
            _mapper = mapper;
            _userReadService = userReadService;
        }
        public async Task<ReadUserDto> Handle(GetAllUserQuerryRequest request, CancellationToken cancellationToken)
        {
            !!!!!!!!!!
            User mapAuthor = _mapper.Map<User>(request);
            var res= await _userReadService.GetAllUser();
            ReadUserDto respnUser = _mapper.Map<ReadUserDto>(res);
            return respnUser;
        }
    }
}
