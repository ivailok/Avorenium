using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface ITermsDomainService
    {
        List<string> GetFilteredTerms(string text, List<string> separators, List<string> filterTerms);
    }
}