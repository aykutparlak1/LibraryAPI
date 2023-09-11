using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Core.ApplicationPipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<ICollection<ObtainedAuthorDto>>, ISecuredRequest
    {
        private readonly string[] roles = { "GetAllAuthor" };
        public string[] Roles => roles;
    }
}
