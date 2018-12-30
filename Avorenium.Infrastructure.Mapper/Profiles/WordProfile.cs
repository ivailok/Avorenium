using AutoMapper;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto.Word;

namespace Avorenium.Infrastructure.Mapper.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>();
            CreateMap<Word, WordDto>();

            CreateMap<WordTypeCreateDto, WordType>();
            CreateMap<WordType, WordTypeDto>();
        }
    }
}