using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto.Word;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface IWordTypesDomainService
    {
         Task<WordTypeDto> GetAsync(string text);

         Task<List<WordTypeDto>> GetListAsync();

         Task<bool> AnyAsync(string text);

         Task<WordTypeDto> CreateAsync(WordTypeCreateDto wordTypeCreateDto);
    }
}