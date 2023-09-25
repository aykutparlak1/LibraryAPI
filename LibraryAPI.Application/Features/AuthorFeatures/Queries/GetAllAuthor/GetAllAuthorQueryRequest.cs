using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<ICollection<ObtainedAuthorDto>>, ISecuredRequest, ICachableRequest
    {
        readonly string roles;
        public GetAllAuthorQueryRequest()
        {
            roles = $"GettAllAuthor";
        }
        //= "GettAllAuthor,Admin";
        public string Roles => roles;

        public string CacheKey => throw new NotImplementedException();

        public TimeSpan? SlidingExpiration => throw new NotImplementedException();

        public int Duration => throw new NotImplementedException();
    }
}
