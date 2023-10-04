using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryAPI.Persistence.Repositories
{
    public  class ReadRepository<T> : IReadRepository<T> where T : class, IEntity, new()
    {

        private readonly DbContext _context;
        private readonly IQueryable<T> _table;
        public ReadRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T?> GetQuery(Expression<Func<T, bool>>? filter=null,  bool AsNotrackingWithIdentityResolution = false,
            ICollection<Func<IQueryable<T>, IIncludableQueryable<T, object>>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
            )
        {
            var query = _table;
            if (AsNotrackingWithIdentityResolution)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = item(query);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }
            if(filter != null)
            {
                query.Where(filter);
            }
            return query;
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, bool AsNotracking = false)
        {
            if (AsNotracking)
            {
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
            }
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }


    }
}
