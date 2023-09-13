using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            var query = filter == null  ? _table.AsNoTracking() : _table.AsNoTracking().Where(filter);
            if (!tracking)
            {
              query =  query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = _table;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.SingleOrDefaultAsync(filter);
        }
    }
}
