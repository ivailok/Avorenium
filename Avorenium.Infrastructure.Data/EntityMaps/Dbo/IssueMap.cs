using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Infrastructure.Data.EntityMaps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Dbo
{
    public class IssueMap : EntityMap<Issue, int>
    {
        public override void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues", "dbo");

            base.Configure(builder);
            
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(300).IsRequired();
        }
    }
}