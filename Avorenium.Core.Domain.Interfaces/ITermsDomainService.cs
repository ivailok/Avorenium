using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface ITermsDomainService
    {
        List<string> SplitTerms(string text);


        List<string> FilterMeaninglessWords(List<string> words);
    }
}