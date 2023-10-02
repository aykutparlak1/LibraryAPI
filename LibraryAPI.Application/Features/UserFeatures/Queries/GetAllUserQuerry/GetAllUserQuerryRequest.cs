using LibraryAPI.Application.Dtos.UserDtos;
using MediatR;

namespace LibraryAPI.Application.Features.UserFeatures.Queries.GetAllUserQuerry
{
    public class GetAllUserQuerryRequest: IRequest<ReadUserDto>
    {
    }
}
