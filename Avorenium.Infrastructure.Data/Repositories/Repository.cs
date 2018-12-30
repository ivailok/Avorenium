using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Base;
using Avorenium.Core.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avorenium.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity, T> : IRepository<TEntity, T>
        where TEntity : class, IEntity<T>
    {
        protected readonly DbSet<TEntity> dbSet;

        public Repository(AvoreniumDbContext dbContext)
        {
            dbSet = dbContext.Set<TEntity>();
        }
        
        public Task<TEntity> GetAsync(int id)
        {
            return dbSet.FindAsync(id);
        }

        public Task<TEntity> GetUniqueAsync(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleOrDefaultAsync(filter);
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, bool shouldTrack = true)
        {
            var query = dbSet.AsQueryable();

            if (!shouldTrack)
            {
                query = query.AsNoTracking();
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
            PrepareToAdd(entity);
            dbSet.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            entities.ForEach(PrepareToAdd);
            dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            PrepareToUpdate(entity);
            dbSet.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(PrepareToUpdate);
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

        private void PrepareToAdd(TEntity entity)
        {
            if (entity is IEntityCreateTrackable)
            {
                (entity as IEntityCreateTrackable).CreatedOn = DateTime.UtcNow;
                (entity as IEntityCreateTrackable).CreatedBy = "Avorenium App";
            }

            if (entity is IEntity<Guid>)
            {
                (entity as IEntity<Guid>).Id = Guid.NewGuid();
            }
        }

        private void PrepareToUpdate(TEntity entity)
        {
            if (entity is IEntityEditTrackable)
            {
                (entity as IEntityEditTrackable).ModifiedOn = DateTime.UtcNow;
                (entity as IEntityEditTrackable).ModifiedBy = "Avorenium App";
            }
        }
    }
}