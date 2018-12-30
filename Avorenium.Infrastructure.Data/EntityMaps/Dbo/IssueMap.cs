using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Infrastructure.Data.EntityMaps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Dbo
{
    public class IssueMap : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues", "dbo");

            EntityMapping.ConfigureSingleKey<Issue, int>(builder);
            EntityMapping.ConfigureCreateTrakable(builder);
            EntityMapping.ConfigureEditTrakable(builder);
            
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(300).IsRequired();

        }
    }
}