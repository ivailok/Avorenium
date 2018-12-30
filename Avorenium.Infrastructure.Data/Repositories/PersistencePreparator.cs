using System;
using Avorenium.Core.Domain.Entities.Data.Base;
using Avorenium.Core.Interfaces.Data.Repositories;

namespace Avorenium.Infrastructure.Data.Repositories
{
    public class PersistencePreparator : IPersistencePreparator
    {
        public void ToAdd<TEntity>(TEntity entity)
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

        public void ToUpdate<TEntity>(TEntity entity)
        {
            if (entity is IEntityEditTrackable)
            {
                (entity as IEntityEditTrackable).ModifiedOn = DateTime.UtcNow;
                (entity as IEntityEditTrackable).ModifiedBy = "Avorenium App";
            }
        }
    }
}