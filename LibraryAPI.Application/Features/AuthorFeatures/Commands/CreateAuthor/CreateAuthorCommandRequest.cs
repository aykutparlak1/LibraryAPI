using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;
using System.Data;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandRequest: IRequest<CommandAuthorDto>, IValidateRequest, ISecuredRequest  // where T : class , IDto, new()
    {

        readonly string role;
        public CreateAuthorCommandRequest()
        {
            role = "CreateAuthor";
        }

        public string Roles => role;

        //public T Dto { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
