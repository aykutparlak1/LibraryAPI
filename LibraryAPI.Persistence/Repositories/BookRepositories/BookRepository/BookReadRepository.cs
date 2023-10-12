using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.BookRepository
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        public BookReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
