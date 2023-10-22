using LibraryAPI.Application.Repositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

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

        public DbSet<T> Table => _context.Set<T>();

        public  T Add(T entity)
        {
           EntityEntry<T> addedEntry = _table.Add(entity);
            return addedEntry.Entity;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = _table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> entities)
        {
            _table.RemoveRange(entities);
            return true;
        }

        public  bool AddRange(List<T> entities)
        {
            _table.AddRange(entities);
            return true;
        }


        public T Update(T entity)
        {
            EntityEntry<T> updatedEntiy =  _table.Update(entity);
            return updatedEntiy.Entity;
        }
        public bool UpdateRange(List<T> entities)
        {
            _table.UpdateRange(entities);
            return true;
        }


        public async Task<int> SaveAsync()
        {
            
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InternalException("Data has been changed or deleted");
            }
            catch (DbUpdateException ex)
            {
                throw new InternalException($"Data is being used. Massage:{ex.Message}");
            }
            catch (Exception ex)
            {
                throw new InternalException($"Unexpected Error. Massage:{ex.Message}");
            }

        }


    }
}
