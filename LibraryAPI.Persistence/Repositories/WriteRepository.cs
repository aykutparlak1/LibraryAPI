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
        public async Task<T> AddAsync(T entity, CancellationToken cancellation)
        {
            await _table.AddAsync(entity, cancellation);
            return entity;
        }

        public void AddRangeAsync(List<T> entities, CancellationToken cancellation)
        {
           _table.AddRangeAsync(entities, cancellation);
        }

        public void Remove(T entity)
        {
             _table.Remove(entity);
        }


        //public async Task Remove(int id)
        //{
        //    WE NEED ADD ID TO BASEENTİTY FOR EVERY ENTİTY
        //    var res = _table.Where(c => c.Id == id);
        //    await Remove(res)
        //}

        public async Task RemoveRange(List<T> entites)
        {
             _table.RemoveRange(entites);
        }
        public  async Task Update(T entity)
        {
            _table.Update(entity);
        }


        public async Task<int> SaveAsync(CancellationToken cancellation)
        {
            
            try
            {
                return await _context.SaveChangesAsync(cancellation);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InternalException("Data has been changed or deleted");
            }
            catch (DbUpdateException)
            {
                throw new InternalException("Data is being used");
            }
            catch (Exception)
            {
                throw new InternalException("Unexpected Error");
            }

        }


    }
}
