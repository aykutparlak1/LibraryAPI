using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
