using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto.Word;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface IWordsDomainService
    {
         Task<List<WordDto>> GetListAsync(int? typeId = null);

         Task<bool> AnyAsync(string text);

         Task<WordDto> CreateAsync(WordCreateDto wordCreateDto);

         Task SaveCollectionAsync(List<string> words, Issue issue);

         Task<bool> DeleteAsync(int id);
    }
}