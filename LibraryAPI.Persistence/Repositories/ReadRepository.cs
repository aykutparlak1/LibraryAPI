﻿using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntity, new()
    {

        private readonly DbContext _context;
        private readonly IQueryable<T> _table;
        public ReadRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public  IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, 
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    bool tracking = false)
        {
            var query = filter == null  ? _table : _table.Where(filter);
            if (!tracking)
            {
              query =  query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if ( orderBy !=null)
            {
                return  orderBy(query);
            }
            return query;
            
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter ,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    bool tracking = false)
        {
            var query = _table;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.SingleOrDefaultAsync(filter);
        }
    }
}
