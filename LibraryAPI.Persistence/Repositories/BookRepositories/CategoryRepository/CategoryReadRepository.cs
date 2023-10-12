using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.CategoryRepository
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
