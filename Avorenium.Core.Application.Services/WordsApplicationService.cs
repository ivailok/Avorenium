using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Enums.Validation;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Data;

namespace Avorenium.Core.Application.Services
{
    public class WordsApplicationService : BaseApplicationService, IWordsApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWordsDomainService wordsDomainService;
        private readonly IWordTypesDomainService wordTypesDomainService;

        public WordsApplicationService(
            IUnitOfWork unitOfWork,
            IWordsDomainService wordsDomainService,
            IWordTypesDomainService wordTypesDomainService)
        {
            this.unitOfWork = unitOfWork;
            this.wordsDomainService = wordsDomainService;
            this.wordTypesDomainService = wordTypesDomainService;
        }

        public async Task<IApplicationResult<List<WordDto>, Enum>> ViewAsync()
        {
            var wordDtos = await wordsDomainService.GetListAsync();

            return new ValueResult<List<WordDto>, Enum>(StatusEnum.EntityRetrieved, wordDtos);
        }

        public async Task<IApplicationResult<WordDto, Enum>> CreateAsync(WordCreateDto wordCreateDto)
        {
            if (IsInvalidRequest(wordCreateDto, out IApplicationResult<WordDto, Enum> result))
            {
                return result;
            }

            var wordExists = await wordsDomainService.AnyAsync(wordCreateDto.Text);

            if (wordExists)
            {
                return new ValidationResult<WordDto, Enum>(StatusEnum.DuplicatedEntityFound);
            }

            var wordTypeDto = await wordTypesDomainService.GetAsync(wordCreateDto.Type);

            if (wordTypeDto == null)
            {
                return new ValidationResult<WordDto, Enum>(StatusEnum.ValidationFailed, WordValidationEnum.NoSuchType);
            }

            wordCreateDto.TypeId = wordTypeDto.Id;

            var wordDto = await wordsDomainService.CreateAsync(wordCreateDto);

            return new ValueResult<WordDto, Enum>(StatusEnum.EntityCreated, wordDto);
        }

        public async Task<IApplicationResult> DeleteAsync(int id)
        {
            var isDeleted = await wordsDomainService.DeleteAsync(id);

            if (!isDeleted)
            {
                return new ApplicationResult(StatusEnum.EntityNotFound);
            }

            await unitOfWork.CompleteAsync();

            return new ApplicationResult(StatusEnum.EntityDeleted);
        }
    }
}