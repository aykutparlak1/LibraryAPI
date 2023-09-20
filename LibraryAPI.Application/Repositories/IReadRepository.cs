
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class , IEntity , new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null
                                    );
        Task<T> GetAsync(Expression<Func<T, bool>>? filter,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    bool AsNotrackingWithIdentityResolution = false);

        IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    bool AsNotrackingWithIdentityResolution = false);
    }
}
