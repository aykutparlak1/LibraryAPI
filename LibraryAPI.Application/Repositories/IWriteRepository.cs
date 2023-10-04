
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        Task<T> AddAsync(T entity, CancellationToken cancellation);
        Task AddRangeAsync(List<T> entities , CancellationToken cancellation);
        Task Remove(T entity);
        Task RemoveRange(List<T> entites);
        Task Update(T entity);
        Task<int> SaveAsync(CancellationToken cancellation);
    }
}
