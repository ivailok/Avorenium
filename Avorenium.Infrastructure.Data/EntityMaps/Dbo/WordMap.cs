using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Infrastructure.Data.EntityMaps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avorenium.Infrastructure.Data.EntityMaps.Dbo
{
    public class WordMap : EntityMap<Word, int>
    {
        public override void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.ToTable("Words", "dbo");

            base.Configure(builder);
            
            builder.Property(x => x.Text).HasColumnName("Text").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.TypeId).HasColumnName("TypeId").HasColumnType("int").IsRequired();

            builder.HasIndex(x => x.Text).IsUnique();

            builder.HasOne(x => x.Type).WithMany().HasForeignKey(x => x.TypeId).IsRequired();
        }
    }
}