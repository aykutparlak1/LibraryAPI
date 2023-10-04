using AutoMapper;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Services.UserService;
using MediatR;

namespace LibraryAPI.Application.Features.UserFeatures.Queries.GetAllUserQuerry
{
    public class GetAllUserQuerryHandler : IRequestHandler<GetAllUserQuerryRequest, List<ReadUserDto>>
    {
        private readonly IUserReadService _userReadService;
        private readonly IMapper _mapper;
        public GetAllUserQuerryHandler(IUserReadService userReadService, IMapper mapper)
        {
            _mapper = mapper;
            _userReadService = userReadService;
        }
        public async Task<List<ReadUserDto>> Handle(GetAllUserQuerryRequest request, CancellationToken cancellationToken)
        {
            var res = await _userReadService.GetAllUser();
            List<ReadUserDto> respnUser = _mapper.Map<List<ReadUserDto>>(res);
            return respnUser;
        }
    }
}
