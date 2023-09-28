using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<ICollection<ObtainedAuthorDto>>, ISecuredRequest//, ICachableRequest
    {
        //= "GettAllAuthor,Admin";
        public string Roles => "GettAllAuthor";
        //public string CacheKey => "GetAllAuthorQuery";
        //public string CacheGroup => "AuthorQuery";
        //public TimeSpan? SlidingExpiration => null;
    }
}
