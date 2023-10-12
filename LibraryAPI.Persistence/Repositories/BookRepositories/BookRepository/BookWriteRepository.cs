using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.BookRepository
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        public BookWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
