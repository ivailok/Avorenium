using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Base;
using Avorenium.Core.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Avorenium.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity, T> : IRepository<TEntity, T>
        where TEntity : class, IEntity<T>
    {
        protected readonly DbSet<TEntity> dbSet;
        protected readonly IPersistencePreparator persistencePreparator;

        public Repository(
            AvoreniumDbContext dbContext,
            IPersistencePreparator persistencePreparator)
        {
            dbSet = dbContext.Set<TEntity>();
            this.persistencePreparator = persistencePreparator;
        }
        
        public Task<TEntity> GetAsync(int id)
        {
            return dbSet.FindAsync(id);
        }

        public Task<TEntity> GetUniqueAsync(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleOrDefaultAsync(filter);
        }

        public Task<List<TEntity>> GetListAsync(
            bool shouldTrack = true,
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = dbSet.AsQueryable();

            if (!shouldTrack)
            {
                query = query.AsNoTracking();
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToListAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.AnyAsync(filter);
        }

        public void Add(TEntity entity)
        {
            persistencePreparator.ToAdd(entity);
            dbSet.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            entities.ForEach(persistencePreparator.ToAdd);
            dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            persistencePreparator.ToUpdate(entity);
            dbSet.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(persistencePreparator.ToUpdate);
            dbSet.UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}