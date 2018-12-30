using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto.Word;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface IWordsDomainService
    {
         Task<List<WordDto>> GetListAsync();

         Task<bool> AnyAsync(string text);

         Task<WordDto> CreateAsync(WordCreateDto wordCreateDto);
    }
}