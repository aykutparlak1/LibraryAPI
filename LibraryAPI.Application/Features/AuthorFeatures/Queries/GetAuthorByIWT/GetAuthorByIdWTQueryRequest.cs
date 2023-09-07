using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAuthorByIWT
{
    public class GetAuthorByIdWTQueryRequest : IRequest<ObtainedAuthorDto>
    {
        public int Id { get; set; }

        public GetAuthorByIdWTQueryRequest(int id)
        {
            Id = id;
        }
    }
}
