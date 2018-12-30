using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Data;
using Avorenium.Core.Interfaces.Data.Repositories;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Core.Domain.Services
{
    public class WordsDomainService : IWordsDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersistencePreparator persistencePreparator;
        private readonly IWordsRepository wordsRepository;
        private readonly IMapperService mapperService;

        public WordsDomainService(
            IUnitOfWork unitOfWork,
            IPersistencePreparator persistencePreparator,
            IWordsRepository wordsRepository,
            IMapperService mapperService)
        {
            this.unitOfWork = unitOfWork;
            this.persistencePreparator = persistencePreparator;
            this.wordsRepository = wordsRepository;
            this.mapperService = mapperService;
        }

        public async Task<List<WordDto>> GetListAsync(int? typeId = null)
        {
            Expression<Func<Word, bool>> filter = null;

            if (typeId.HasValue)
            {
                filter = x => x.Type.Id == typeId;
            }

            var words = await wordsRepository.GetListAsync(false, filter, x => x.Type);
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

        public async Task SaveCollectionAsync(List<string> words, Issue issue)
        {
            var storedWords = await wordsRepository.GetListIncludingIssuesAsync(true, x => words.Contains(x.Text));
            var storedWordsDictionary = storedWords.ToDictionary(x => x.Text);

            var updateList = new List<Word>();
            var createList = new List<Word>();

            foreach (var word in words)
            {
                if (storedWordsDictionary.ContainsKey(word))
                {
                    var currentStoredWord = storedWordsDictionary[word];
                    var issueWord = new IssueWord
                    {
                        Issue = issue
                    };
                    persistencePreparator.ToAdd(issueWord);
                    currentStoredWord.Issues.Add(issueWord);
                    updateList.Add(currentStoredWord);
                }
                else
                {
                    var issueWord = new IssueWord
                    {
                        Issue = issue
                    };
                    persistencePreparator.ToAdd(issueWord);
                    createList.Add(new Word 
                    { 
                        Text = word, 
                        TypeId = 1, 
                        Issues = new List<IssueWord>
                        {
                            issueWord
                        }
                    });
                }
            }

            wordsRepository.AddRange(createList);
            wordsRepository.UpdateRange(updateList);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var wordType = await wordsRepository.GetAsync(id);

            if (wordType == null)
            {
                return false;
            }

            wordsRepository.Remove(wordType);

            return true;
        }
    }
}