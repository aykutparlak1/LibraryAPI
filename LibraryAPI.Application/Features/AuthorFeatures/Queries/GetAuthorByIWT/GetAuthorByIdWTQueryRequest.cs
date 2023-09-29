using LibraryAPI.Application.Dtos.AuthorDtos;

using MediatR;
using Microsoft.AspNetCore.Authorization;

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
