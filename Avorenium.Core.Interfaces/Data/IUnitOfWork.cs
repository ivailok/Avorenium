using System.Threading.Tasks;

namespace Avorenium.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}