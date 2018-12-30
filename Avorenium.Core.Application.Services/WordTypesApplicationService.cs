using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Domain.Interfaces;

namespace Avorenium.Core.Application.Services
{
    public class WordTypesApplicationService : BaseApplicationService, IWordTypesApplicationService
    {
        private readonly IWordTypesDomainService wordTypesDomainService;

        public WordTypesApplicationService(
            IWordTypesDomainService wordTypesDomainService)
        {
            this.wordTypesDomainService = wordTypesDomainService;
        }

        public async Task<IApplicationResult<List<WordTypeDto>, Enum>> ViewAsync()
        {
            var wordTypeDtos = await wordTypesDomainService.GetListAsync();

            return new ValueResult<List<WordTypeDto>, Enum>(StatusEnum.EntityRetrieved, wordTypeDtos);
        }

        public async Task<IApplicationResult<WordTypeDto, Enum>> CreateAsync(WordTypeCreateDto wordTypeCreateDto)
        {
            if (IsInvalidRequest(wordTypeCreateDto, out IApplicationResult<WordTypeDto, Enum> result))
            {
                return result;
            }

            var wordTypeExists = await wordTypesDomainService.AnyAsync(wordTypeCreateDto.Text);

            if (wordTypeExists)
            {
                return new ValidationResult<WordTypeDto, Enum>(StatusEnum.DuplicatedEntityFound);
            }

            var wordTypeDto = await wordTypesDomainService.CreateAsync(wordTypeCreateDto);

            return new ValueResult<WordTypeDto, Enum>(StatusEnum.EntityCreated, wordTypeDto);
        }
    }
}