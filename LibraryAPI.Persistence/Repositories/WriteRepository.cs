using LibraryAPI.Application.Repositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<bool> AddAsync(T entity)
        {
           EntityEntry<T> entityEntry = await _table.AddAsync(entity);
            return entityEntry.State==EntityState.Added;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = _table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        //public async Task<bool> RemoveAsync(string id)
        //{
        //    T model = await Table.FirstOrDefaultAsync(data => data== Guid.Parse(id));
        //    return Remove(model);
        //}
        public async Task<List<T>> AddRange(List<T> entity)
        {
            await _table.AddRangeAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
           _table.Update(entity);
            return entity;
        }
        public List<T> UpdateRange(List<T> entities)
        {
            _table.UpdateRange(entities);
            return entities;
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
