﻿using Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Application.Repositories;
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
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public async Task Remove(T entity)
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
