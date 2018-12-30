using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Interfaces.Data.Repositories;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Avorenium.Infrastructure.Data.Repositories.Dbo
{
    public class IssuesRepository : Repository<Issue, int>, IIssuesRepository
    {
        public IssuesRepository(
            AvoreniumDbContext dbContext,
            IPersistencePreparator persistencePreparator)
            : base(dbContext, persistencePreparator)
        {
        }

        public Task<List<Issue>> GetListIncludingWordsAsync()
        {
            var result = dbSet
                .AsNoTracking()
                .Include(x => x.Words).ThenInclude(x => x.Word)
                .ToListAsync();

            return result;
        }
    }
}