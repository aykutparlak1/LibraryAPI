using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandRequest : IRequest<CreatedAuthorDto>
    {
        public string AuthorName { get; set; }
    }
}
