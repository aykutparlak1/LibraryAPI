using AutoMapper;
using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GettAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, ICollection<ObtainedAuthorDto>>
    {

        IAuthorReadRepository _authorReadRepository;
        IMapper _mapper;
        public GettAllAuthorQueryHandler(IAuthorReadRepository authorReadRepository, IMapper mapper) 
        {
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<ObtainedAuthorDto>> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            ICollection<Author> authors =  await _authorReadRepository.GetAll(null,false).ToListAsync();
            ICollection<ObtainedAuthorDto> model = _mapper.Map<ICollection<ObtainedAuthorDto>>(authors);
            return model;
        }
    }
}
