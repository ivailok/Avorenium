using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;

namespace Avorenium.Infrastructure.Data.Repositories.Dbo
{
    public class IssuesRepository : Repository<Issue, int>, IIssuesRepository
    {
        public IssuesRepository(AvoreniumDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}