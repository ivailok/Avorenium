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
        protected readonly AvoreniumDbContext dbContext;

        public Repository(AvoreniumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public Task<TEntity> GetAsync(int id)
        {
            return dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, bool shouldTrack = true)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();

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

        public void Add(TEntity entity)
        {
            PrepareToAdd(entity);
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            entities.ForEach(PrepareToAdd);
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            PrepareToUpdate(entity);
            dbContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(PrepareToUpdate);
            dbContext.Set<TEntity>().UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
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