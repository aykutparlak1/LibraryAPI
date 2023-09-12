using AutoMapper;
using LibraryAPI.Application.Dtos;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, CommandAuthorDto>
    {

        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IMapper mapper)
        {
            _authorWriteRepository = authorWriteRepository;
            _mapper = mapper;
        }
        async Task<CommandAuthorDto> IRequestHandler<CreateAuthorCommandRequest, CommandAuthorDto>.Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {

            Author mappedAuthor=_mapper.Map<Author>(request);
            await _authorWriteRepository.AddAsync(mappedAuthor);
            CommandAuthorDto createdAuthorDto = _mapper.Map<CommandAuthorDto>(mappedAuthor);
            return createdAuthorDto;
        }
    }
}
