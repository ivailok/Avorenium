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
    public class WordsDomainService : IWordsDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWordsRepository wordsRepository;
        private readonly IMapperService mapperService;

        public WordsDomainService(
            IUnitOfWork unitOfWork,
            IWordsRepository wordsRepository,
            IMapperService mapperService)
        {
            this.unitOfWork = unitOfWork;
            this.wordsRepository = wordsRepository;
            this.mapperService = mapperService;
        }

        public async Task<List<WordDto>> GetListAsync()
        {
            var words = await wordsRepository.GetListAsync(null, false, x => x.Type);
            var wordDtos = mapperService.Map<List<WordDto>>(words);

            return wordDtos;
        }

        public Task<bool> AnyAsync(string text)
        {
            return wordsRepository.AnyAsync(x => x.Text == text);
        }

        public async Task<WordDto> CreateAsync(WordCreateDto wordCreateDto)
        {
            var word = mapperService.Map<Word>(wordCreateDto);
            
            wordsRepository.Add(word);
            await unitOfWork.CompleteAsync();

            var wordDto = mapperService.Map<WordDto>(word);

            return wordDto;
        }
    }
}