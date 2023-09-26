using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<ICollection<ObtainedAuthorDto>>, ISecuredRequest, ICachableRequest
    {
        readonly string role;
        readonly string key;
        readonly string cacheGroup;
        public GetAllAuthorQueryRequest()
        {
            role = "GettAllAuthor";
            key = "GetAllAuthorQuery";
            cacheGroup = "AuthorQuery";
        }
        //= "GettAllAuthor,Admin";
        public string Roles => role;
        public string CacheKey => key;
        public string CacheGroup => cacheGroup;


        public TimeSpan? SlidingExpiration => null;
    }
}
