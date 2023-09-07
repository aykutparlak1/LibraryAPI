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

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAuthorByIWT
{
    public class GetAuthorByIdWTQueryHandler : IRequestHandler<GetAuthorByIdWTQueryRequest, ObtainedAuthorDto>
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;
        public GetAuthorByIdWTQueryHandler(IAuthorReadRepository authorReadRepository , IMapper mapper)
        {
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }
        public async Task<ObtainedAuthorDto> Handle(GetAuthorByIdWTQueryRequest request, CancellationToken cancellationToken)
        {
            Author res = await _authorReadRepository.GetAsync(p => p.Id == request.Id, true);
            ObtainedAuthorDto obtainedAuthorDto = _mapper.Map<ObtainedAuthorDto>(res);
            return obtainedAuthorDto;
        }
    }
}
