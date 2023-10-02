using LibraryAPI.Application.Repositories;
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

        public IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter=null,  bool AsNotrackingWithIdentityResolution = false)
        {
            var query = filter == null ? _table : _table.Where(filter);
            if (AsNotrackingWithIdentityResolution)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return query;
        }
        public IQueryable<T> IncludeQuery(IQueryable<T> query,
                                   ICollection< Func<IQueryable<T>, IIncludableQueryable<T, object>>?> include) 
        {
            foreach (var item in include) 
            {
                query = item(query);
            }
            return query;
        }
        public  IQueryable<T> OrderedQuery(IQueryable<T> query,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            if ( orderBy !=null)
            {
                return  orderBy(query);
            }
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter ,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    bool AsNotrackingWithIdentityResolution = false)
        {
            var query = _table.AsQueryable();
            if (AsNotrackingWithIdentityResolution)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        
    }
}
