using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Rules
{
    public class AuthorBusinessRules
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        public AuthorBusinessRules(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }


    }
}
