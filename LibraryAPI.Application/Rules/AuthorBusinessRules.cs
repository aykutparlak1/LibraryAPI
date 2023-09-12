using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;

namespace LibraryAPI.Application.Rules
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
