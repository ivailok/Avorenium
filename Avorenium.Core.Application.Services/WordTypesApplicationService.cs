using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Data;

namespace Avorenium.Core.Application.Services
{
    public class WordTypesApplicationService : BaseApplicationService, IWordTypesApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWordTypesDomainService wordTypesDomainService;

        public WordTypesApplicationService(
            IUnitOfWork unitOfWork,
            IWordTypesDomainService wordTypesDomainService)
        {
            this.unitOfWork = unitOfWork;
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

        public async Task<IApplicationResult> DeleteAsync(int id)
        {
            var isDeleted = await wordTypesDomainService.DeleteAsync(id);

            if (!isDeleted)
            {
                return new ApplicationResult(StatusEnum.EntityNotFound);
            }

            await unitOfWork.CompleteAsync();

            return new ApplicationResult(StatusEnum.EntityDeleted);
        }
    }
}