
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        Task<T> AddAsync(T entity);
        T Remove(T entity);
        Task<List<T>> AddRange(List<T> entity);
        T Update(T entity);
        List<T> UpdateRange(List<T> entity);
        Task<int> SaveAsync();
    }
}
