using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;


namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandRequest: IRequest<CommandAuthorDto>, IValidateRequest, ISecuredRequest  // where T : class , IDto, new()
    {
        public string Roles { get; }
        public CreateAuthorCommandRequest()
        {
            Roles = "CreateAuthor";
        }

        //public T Dto { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
