using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;

namespace Avorenium.Core.Interfaces.Data.Repositories.Dbo
{
    public interface IIssuesRepository : IRepository<Issue, int>
    {
        Task<List<Issue>> GetListIncludingWordsAsync();
    }
}