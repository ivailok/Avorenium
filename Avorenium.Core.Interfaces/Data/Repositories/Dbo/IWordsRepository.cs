using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;

namespace Avorenium.Core.Interfaces.Data.Repositories.Dbo
{
    public interface IWordsRepository : IRepository<Word, int>
    {
        Task<List<Word>> GetListIncludingIssuesAsync(
            bool shouldTrack = true,
            Expression<Func<Word, bool>> filter = null);
    }
}