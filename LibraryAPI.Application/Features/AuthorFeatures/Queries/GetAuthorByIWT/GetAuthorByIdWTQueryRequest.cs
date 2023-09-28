using LibraryAPI.Application.Dtos.AuthorDtos;

using MediatR;

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
