using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Interfaces.Data.Repositories;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;

namespace Avorenium.Infrastructure.Data.Repositories.Dbo
{
    public class WordTypesRepository : Repository<WordType, int>, IWordTypesRepository
    {
        public WordTypesRepository(
            AvoreniumDbContext dbContext,
            IPersistencePreparator persistencePreparator)
            : base(dbContext, persistencePreparator)
        {
        }
    }
}