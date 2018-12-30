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
    public class WordsRepository : Repository<Word, int>, IWordsRepository
    {
        public WordsRepository(
            AvoreniumDbContext dbContext,
            IPersistencePreparator persistencePreparator)
            : base(dbContext, persistencePreparator)
        {
        }

        public Task<List<Word>> GetListIncludingIssuesAsync(
            bool shouldTrack = true,
            Expression<Func<Word, bool>> filter = null)
        {
            var query = dbSet.AsQueryable();

            if (!shouldTrack)
            {
                query = query.AsNoTracking();
            }

            query = query.Include(x => x.Issues).ThenInclude(x => x.Word);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToListAsync();
        }
    }
}