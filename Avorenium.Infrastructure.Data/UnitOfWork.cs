using System;
using System.Threading.Tasks;
using Avorenium.Core.Interfaces.Data;

namespace Avorenium.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AvoreniumDbContext dbContext;

        public UnitOfWork(
            AvoreniumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}