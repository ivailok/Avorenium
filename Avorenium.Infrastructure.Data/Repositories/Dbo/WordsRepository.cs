using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;

namespace Avorenium.Infrastructure.Data.Repositories.Dbo
{
    public class WordsRepository : Repository<Word, int>, IWordsRepository
    {
        public WordsRepository(AvoreniumDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}