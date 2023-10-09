
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        Task<T> AddAsync(T entity);
        void AddRangeAsync(List<T> entitiess);
        void Remove(T entity);
        Task Update(T entity);
        Task<int> SaveAsync();
    }
}
