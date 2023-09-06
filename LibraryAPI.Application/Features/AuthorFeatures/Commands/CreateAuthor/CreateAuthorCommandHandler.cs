using AutoMapper;
using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, CreatedAuthorDto>
    {

        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IMapper mapper)
        {
            _authorWriteRepository = authorWriteRepository;
            _mapper = mapper;
        }
        async Task<CreatedAuthorDto> IRequestHandler<CreateAuthorCommandRequest, CreatedAuthorDto>.Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {

            Author mappedAuthor=_mapper.Map<Author>(request);
            await _authorWriteRepository.AddAsync(mappedAuthor);
            CreatedAuthorDto createdAuthorDto = _mapper.Map<CreatedAuthorDto>(mappedAuthor);
            return createdAuthorDto;
        }
    }
}
