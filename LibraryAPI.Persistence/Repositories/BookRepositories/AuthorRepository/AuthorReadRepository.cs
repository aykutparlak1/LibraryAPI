using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.AuthorRepository
{
    public class AuthorReadRepository : ReadRepository<Author>, IAuthorReadRepository
    {
        public AuthorReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
