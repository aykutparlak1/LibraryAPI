using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Enums;
using LibraryAPI.Application.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<ICollection<ObtainedAuthorDto>>, ISecuredRequest
    {
        readonly string roles;
        public GetAllAuthorQueryRequest()
        {
            roles = $"GettAllAuthor,{(int)UserTypes.User},{(int)UserTypes.Employee},{(int)UserTypes.Manager}";
        }
        //= "GettAllAuthor,Admin";
        public string[] Roles => roles.Split(',');
    }
}
