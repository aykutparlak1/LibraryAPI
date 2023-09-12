using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IMapper _mapper;
        public DeleteAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IMapper mapper)
        {
            _authorWriteRepository = authorWriteRepository; 
            _mapper = mapper;
        }


        public async Task Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {

            Author deltAuthor = _mapper.Map<Author>(request);
            await _authorWriteRepository.Remove(deltAuthor);
        }
    }
}
