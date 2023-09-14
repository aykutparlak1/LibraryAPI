
using LibraryAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity , new()
    {

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task Remove(T entity);
        Task RemoveRange(List<T> entites);
        Task Update(T entity);
        Task<int> SaveAsync();
    }
}
