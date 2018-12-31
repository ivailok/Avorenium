using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<List<Issue>> GetListIncludingWordsAsync(bool shouldTrack = true, Expression<Func<Issue, bool>> predicate = null)
        {
            var query = dbSet.AsQueryable();

            if (!shouldTrack)
            {
                query = query.AsNoTracking();
            }

            query = query.Include(x => x.Words).ThenInclude(x => x.Word);

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToListAsync();
        }
    }
}