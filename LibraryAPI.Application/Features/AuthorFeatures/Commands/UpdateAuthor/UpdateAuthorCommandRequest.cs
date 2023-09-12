using LibraryAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandRequest : IRequest<CommandAuthorDto>
    {
        public int Id { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }
    }
}
