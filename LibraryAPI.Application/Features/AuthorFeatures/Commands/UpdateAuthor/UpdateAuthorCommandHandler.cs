using AutoMapper;
using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, CommandAuthorDto>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IMapper mapper)
        {
            _authorWriteRepository = authorWriteRepository;
            _mapper = mapper;
        }

        public async Task<CommandAuthorDto> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            Author mapAuthor = _mapper.Map<Author>(request);
            await _authorWriteRepository.Update(mapAuthor);
            CommandAuthorDto updtAuthor = _mapper.Map<CommandAuthorDto>(mapAuthor);
            return updtAuthor;
        }
    }
}
