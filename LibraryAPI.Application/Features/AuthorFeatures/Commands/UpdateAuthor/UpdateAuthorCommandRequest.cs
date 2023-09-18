using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandRequest : IRequest<CommandAuthorDto> , IValidateRequest
    {
        public int Id { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }
    }
}
