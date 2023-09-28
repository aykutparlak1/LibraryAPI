using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandRequest : IRequest , IValidateRequest, ISecuredRequest// , ICacheRemoveRequest
    {
        public int Id { get; set; }

        public string Roles { get; }
        public DeleteAuthorCommandRequest()
        {
            Roles = "DeleteAuthor";
        }

        // public string CacheGroup => "AuthorQuery";

    }
}
