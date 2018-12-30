using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Data;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Core.Domain.Services
{
    public class WordTypesDomainService : IWordTypesDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWordTypesRepository wordTypesRepository;
        private readonly IMapperService mapperService;

        public WordTypesDomainService(
            IUnitOfWork unitOfWork,
            IWordTypesRepository wordTypesRepository,
            IMapperService mapperService)
        {
            this.unitOfWork = unitOfWork;
            this.wordTypesRepository = wordTypesRepository;
            this.mapperService = mapperService;
        }

        public async Task<WordTypeDto> GetAsync(string text)
        {
            var wordType = await wordTypesRepository.GetUniqueAsync(x => x.Text == text);
            var wordTypeDto = mapperService.Map<WordTypeDto>(wordType);

            return wordTypeDto;
        }

        public async Task<List<WordTypeDto>> GetListAsync()
        {
            var wordTypes = await wordTypesRepository.GetListAsync(shouldTrack: false);
            var wordTypeDtos = mapperService.Map<List<WordTypeDto>>(wordTypes);

            return wordTypeDtos;
        }

        public Task<bool> AnyAsync(string text)
        {
            return wordTypesRepository.AnyAsync(x => x.Text == text);
        }

        public async Task<WordTypeDto> CreateAsync(WordTypeCreateDto wordTypeCreateDto)
        {
            var wordType = mapperService.Map<WordType>(wordTypeCreateDto);
            
            wordTypesRepository.Add(wordType);
            await unitOfWork.CompleteAsync();

            var wordTypeDto = mapperService.Map<WordTypeDto>(wordType);

            return wordTypeDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var wordType = await wordTypesRepository.GetAsync(id);

            if (wordType == null)
            {
                return false;
            }

            wordTypesRepository.Remove(wordType);

            return true;
        }
    }
}