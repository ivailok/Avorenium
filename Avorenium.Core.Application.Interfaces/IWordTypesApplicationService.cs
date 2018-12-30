using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Entities.Results;

namespace Avorenium.Core.Application.Interfaces
{
    public interface IWordTypesApplicationService
    {
        Task<IApplicationResult<List<WordTypeDto>, Enum>> ViewAsync();

        Task<IApplicationResult<WordTypeDto, Enum>> CreateAsync(WordTypeCreateDto wordTypeCreateDto);
    }
}