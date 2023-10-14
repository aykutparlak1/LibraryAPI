using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.PublisherRepository
{
    public class PublisherWriteRepository : WriteRepository<Publisher>, IPublisherWriteRepository
    {
        public PublisherWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
