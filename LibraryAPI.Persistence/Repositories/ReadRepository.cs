using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities.BaseEntity;
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
        public ReadRepository(LibraryContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
 
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _table.AsNoTracking() : _table.AsNoTracking().Where(filter);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _table.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(filter);
        }
    }
}
