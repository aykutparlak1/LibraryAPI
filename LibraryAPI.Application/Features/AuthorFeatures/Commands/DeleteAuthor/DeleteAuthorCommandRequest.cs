using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteAuthorCommandRequest(int id) 
        {
            Id = id;
        }
    }
}
