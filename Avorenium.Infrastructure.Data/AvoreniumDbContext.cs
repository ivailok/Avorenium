using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Infrastructure.Data.EntityMaps.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Avorenium.Infrastructure.Data
{
    public class AvoreniumDbContext : DbContext
    {
        public AvoreniumDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IssueMap());
            modelBuilder.ApplyConfiguration(new WordMap());
            modelBuilder.ApplyConfiguration(new WordTypeMap());
            modelBuilder.ApplyConfiguration(new IssueWordMap());
        }
    }
}