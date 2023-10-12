using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.AuthorRepository
{
    public class AuthorWriteRepository : WriteRepository<Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
