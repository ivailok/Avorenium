using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Infrastructure.Data.EntityMaps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Dbo
{
    public class IssueWordMap : IEntityTypeConfiguration<IssueWord>
    {
        public void Configure(EntityTypeBuilder<IssueWord> builder)
        {
            builder.ToTable("IssueWords", "dbo");

            builder.HasKey(x => new { x.IssueId, x.WordId });

            builder.Property(x => x.IssueId).HasColumnName("IssueId").HasColumnType("int").IsRequired();
            builder.Property(x => x.WordId).HasColumnName("WordId").HasColumnType("int").IsRequired();

            EntityMapping.ConfigureCreateTrakable(builder);
            EntityMapping.ConfigureEditTrakable(builder);

            builder.HasOne(x => x.Issue).WithMany(x => x.Words).HasForeignKey(x => x.IssueId);
            builder.HasOne(x => x.Word).WithMany(x => x.Issues).HasForeignKey(x => x.WordId);
        }
    }
}