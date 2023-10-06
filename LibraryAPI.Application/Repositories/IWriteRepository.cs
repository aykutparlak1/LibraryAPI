
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        Task<T> AddAsync(T entity, CancellationToken cancellation);
        void AddRangeAsync(List<T> entities , CancellationToken cancellation);
        void Remove(T entity);
        Task RemoveRange(List<T> entites);
        Task Update(T entity);
        Task<int> SaveAsync(CancellationToken cancellation);
    }
}
