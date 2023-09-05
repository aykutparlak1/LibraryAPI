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
        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await _table.AddAsync(entity);
            await SaveAsync();
            return entityEntry.Entity;

        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = _table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> entites)
        {
             _table.RemoveRange(entites);
            return true;
        }
        public  bool Update(T entity)
        {
           EntityEntry<T> entityEntry = _table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
