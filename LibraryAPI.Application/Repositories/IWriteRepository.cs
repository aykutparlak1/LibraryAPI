
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        Task<T> AddAsync(T entity);
        Task Remove(T entity);
        Task<List<T>> AddRange(List<T> entity);
        Task<T> Update(T entity);
        Task<int> SaveAsync();
    }
}
