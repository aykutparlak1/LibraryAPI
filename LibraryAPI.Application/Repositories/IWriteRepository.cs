
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        T Add(T entity);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        T Update(T entity);
        bool UpdateRange(List<T> entities);
        bool AddRange(List<T> entities);
        Task<int> SaveAsync();
    }
}
