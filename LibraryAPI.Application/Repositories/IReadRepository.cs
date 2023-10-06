using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryAPI.Application.Repositories
{
    public  interface IReadRepository<T> : IRepository<T> where T : class , IEntity , new()
    {
        IQueryable<T?> GetQuery(Expression<Func<T, bool>>? filter = null, bool AsNotrackingWithIdentityResolution = false,
                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
                    );
        Task<T?> GetAsync(Expression<Func<T, bool>>? filter);
        Task<bool> IsExist(Expression<Func<T, bool>> expression);


    }
}
