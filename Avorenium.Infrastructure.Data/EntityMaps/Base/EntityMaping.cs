using System;
using Avorenium.Core.Domain.Entities.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Base
{
    public static class EntityMapping
    {
        public static void ConfigureSingleKey<TEntity, T>(EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IEntity<T>
        {
            builder.HasKey(x => x.Id);

            string columnType = string.Empty;

            if (typeof(T) == typeof(int))
            {
                columnType = "int";
            }

            if (typeof(T) == typeof(Guid))
            {
                columnType = "char(16)";
            }

            if (columnType == string.Empty)
            {
                throw new InvalidOperationException($"Cannot setup entity key of type {typeof(T)}.");
            }

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(columnType).IsRequired();
        }
    
        public static void ConfigureCreateTrakable<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IEntityCreateTrackable
        {
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("timestamp").HasMaxLength(3).IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasColumnType("varchar").HasMaxLength(250).IsRequired();
        }

        public static void ConfigureEditTrakable<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IEntityEditTrackable
        {
            builder.Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").HasColumnType("timestamp").HasMaxLength(3); 
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasColumnType("varchar").HasMaxLength(250);
        }
    }
}