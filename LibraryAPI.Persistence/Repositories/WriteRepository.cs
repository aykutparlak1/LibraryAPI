using LibraryAPI.Application.Repositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            await _table.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task Remove(T entity)
        {
             _table.Remove(entity);
             await SaveAsync();
        }

        public  async Task<T> Update(T entity)
        {
            _table.Update(entity);
            await SaveAsync();
            return entity;
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
