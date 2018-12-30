using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Entities.Results;

namespace Avorenium.Core.Application.Interfaces
{
    public interface IWordsApplicationService
    {
        Task<IApplicationResult<List<WordDto>, Enum>> ViewAsync();

        Task<IApplicationResult<WordDto, Enum>> CreateAsync(WordCreateDto wordCreateDto);
    }
}