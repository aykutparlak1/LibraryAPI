using LibraryAPI.Application.Dtos;
using LibraryAPI.Core.ApplicationPipelines.Authorization;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<ICollection<ObtainedAuthorDto>>, ISecuredRequest
    {
        readonly string roles;
        public GetAllAuthorQueryRequest()
        {
            roles = "GettAllAuthor,Admin";
        }
        //= "GettAllAuthor,Admin";
        public string[] Roles => roles.Split(',');
    }
}
