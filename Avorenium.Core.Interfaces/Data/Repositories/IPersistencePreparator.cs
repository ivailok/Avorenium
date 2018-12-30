namespace Avorenium.Core.Interfaces.Data.Repositories
{
    public interface IPersistencePreparator
    {
        void ToAdd<TEntity>(TEntity entity);

        void ToUpdate<TEntity>(TEntity entity);
    }
}