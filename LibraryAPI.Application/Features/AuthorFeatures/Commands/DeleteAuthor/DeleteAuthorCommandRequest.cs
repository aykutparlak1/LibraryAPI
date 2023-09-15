using LibraryAPI.Core.ApplicationPipelines.Validation;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandRequest : IRequest , IValidateRequest
    {
        public int Id { get; set; }

        public DeleteAuthorCommandRequest(int id) 
        {
            Id = id;
        }
    }
}
