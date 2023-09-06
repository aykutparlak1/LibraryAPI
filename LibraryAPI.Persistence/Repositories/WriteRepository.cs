using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity, new()
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _table;
        public WriteRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await SaveAsync();
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            await SaveAsync();
        }

        public async Task Remove(T entity)
        {
             _table.Remove(entity);
            await SaveAsync() ;
        }
        public async Task RemoveRange(List<T> entites)
        {
             _table.RemoveRange(entites);
            await SaveAsync() ;
        }
        public  async Task Update(T entity)
        {
            _table.Update(entity);
            await SaveAsync();
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
