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
            _table = _context.Set<T>();
        }

        public DbSet<T> Table => _context.Set<T>();

        //Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        public IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params string[] includes)
        {
            var query = _table;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }


        public async Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

    }
}
