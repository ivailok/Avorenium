using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Infrastructure.Data.EntityMaps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Dbo
{
    public class WordTypeMap : IEntityTypeConfiguration<WordType>
    {
        public void Configure(EntityTypeBuilder<WordType> builder)
        {
            builder.ToTable("WordTypes", "dbo");

            EntityMapping.ConfigureSingleKey<WordType, int>(builder);
            EntityMapping.ConfigureCreateTrakable(builder);
            EntityMapping.ConfigureEditTrakable(builder);
            
            builder.Property(x => x.Text).HasColumnName("Text").HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.Text).IsUnique();
        }
    }
}