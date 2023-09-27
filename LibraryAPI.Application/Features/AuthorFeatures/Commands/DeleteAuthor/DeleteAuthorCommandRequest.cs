using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandRequest : IRequest , IValidateRequest , ICacheRemoveRequest
    {
        public int Id { get; set; }

        public string CacheGroup => "AuthorQuery";

    }
}
