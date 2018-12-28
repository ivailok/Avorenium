using System;
using Avorenium.Core.Domain.Entities.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Base
{
    public abstract class EntityMap<TEntity, T> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity<T>, IEntityCreateTrackable, IEntityEditTrackable
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            string columnType = string.Empty;

            if (typeof(T) == typeof(int))
            {
                columnType = "int";
            }

            if (typeof(T) == typeof(Guid))
            {
                columnType = "uniqueidentifier";
            }

            if (columnType == string.Empty)
            {
                throw new InvalidOperationException($"Cannot setup entity key of type {typeof(T)}.");
            }

            var keyProperty = builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(columnType).IsRequired();

            if (typeof(T) == typeof(int))
            {
                keyProperty.UseNpgsqlIdentityColumn();
            }

            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime").IsRequired();

            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").HasColumnType("datetime"); 
        }
    }
}