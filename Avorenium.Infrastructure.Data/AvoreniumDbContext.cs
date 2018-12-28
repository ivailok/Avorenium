using Avorenium.Core.Domain.Entities.Data.Dbo;
using JetBrains.Annotations;
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
    }
}