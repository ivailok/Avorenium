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

        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IssueMap());
        }
    }
}