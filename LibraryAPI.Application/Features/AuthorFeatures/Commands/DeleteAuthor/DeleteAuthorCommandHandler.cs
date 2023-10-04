using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;
        public DeleteAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository,IAuthorReadRepository authorReadRepository ,IMapper mapper)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository; 
            _mapper = mapper;
        }


        public async Task Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var res = _authorReadRepository.GetAsync(x => x.Id == request.Id);
            Author deltAuthor = _mapper.Map<Author>(res.Result);
            await _authorWriteRepository.Remove(deltAuthor);
            await _authorWriteRepository.SaveAsync(cancellationToken);
        }
    }
}
