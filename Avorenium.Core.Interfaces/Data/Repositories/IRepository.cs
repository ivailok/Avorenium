using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Base;

namespace Avorenium.Core.Interfaces.Data.Repositories
{
    public interface IRepository<TEntity, T>
        where TEntity : class, IEntity<T>
    {
        Task<TEntity> GetAsync(int id);

        Task<TEntity> GetUniqueAsync(Expression<Func<TEntity, bool>> filter);

        Task<List<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> filter = null,
            bool shouldTrack = true,
            params Expression<Func<TEntity, object>>[] includes);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        void Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(List<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(List<TEntity> entities);
    }
}