using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BarrowRepositories.BarrowedBookReadRepository
{
    public class BarrowedBookReadRepository : ReadRepository<BarrowedBook>, IBarrowedBookReadRepository
    {
        public BarrowedBookReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
