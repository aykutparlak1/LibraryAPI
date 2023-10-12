using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.PublisherRepository
{
    public class PublisherReadRepository : ReadRepository<Publisher>, IPublisherReadRepository
    {
        public PublisherReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
