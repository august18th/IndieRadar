using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories.Base;

namespace IndieRadar.Data.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected GenericRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet { get; }
        protected IDbContext DbContext { get; }
        protected virtual IQueryable<TEntity> DetachedQueryable => DbSet.AsNoTracking();

        public async Task<ICollection<TEntity>> GetItemsAsync()
        {
            return await DetachedQueryable.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetItemsAsync(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery)
        {
            if (convertQuery == null)
                throw new ArgumentNullException(nameof(convertQuery));

            return await convertQuery(DetachedQueryable).ToListAsync();
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, Boolean>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await DetachedQueryable.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindFirstAsync(Expression<Func<TEntity, Boolean>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await DetachedQueryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            DbSet.Add(item);
            await DbContext.SaveChangesAsync();
            return item;
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            DbContext.Entry(item).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return item;
        }

        public virtual async Task<Boolean> RemoveAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                DbContext.Entry(item).State = EntityState.Deleted;
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}