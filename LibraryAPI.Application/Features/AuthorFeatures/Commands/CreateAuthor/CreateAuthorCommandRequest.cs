using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Core.ApplicationPipelines.Authorization;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandRequest: IRequest<CommandAuthorDto> , ISecuredRequest // where T : class , IDto, new()
    {

        readonly string roles;
        public CreateAuthorCommandRequest()
        {
            roles = "CreateAuthor,Admin";
        }

        public string[] Roles => roles.Split(',');

        //public T Dto { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
