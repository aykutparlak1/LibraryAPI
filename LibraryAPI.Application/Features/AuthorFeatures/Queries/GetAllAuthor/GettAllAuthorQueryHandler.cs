using AutoMapper;
using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Application.Features.AuthorFeatures.Models;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GettAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, ObtainedAuthorListModel>
    {

        IAuthorReadRepository _authorReadRepository;
        IMapper _mapper;
        public GettAllAuthorQueryHandler(IAuthorReadRepository authorReadRepository, IMapper mapper) 
        {
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }
        public async Task<ObtainedAuthorListModel> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
           IList<Author> authors =  await _authorReadRepository.GetAll(null,false).ToListAsync();
            ObtainedAuthorListModel model = _mapper.Map<ObtainedAuthorListModel>(authors);
            return model;
        }
    }
}
