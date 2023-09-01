using LibraryAPI.Domain.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAcces.Repositories
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
            where TEntity : class, IEntity, new()
            where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext context = new();
            context.Set<TEntity>().Add(entity);
            context.Set<TEntity>().AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();

            return context.Set<TEntity>().AsNoTrackingWithIdentityResolution().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new();
            //filtre null ise hepsini getir değil ise filteri halini getir
            return filter == null ? context.Set<TEntity>().AsNoTracking().ToList()
                : context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }


    }
}
