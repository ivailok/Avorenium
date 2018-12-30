using AutoMapper;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto.Word;

namespace Avorenium.Infrastructure.Mapper.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>()
                .ForMember(dest => dest.Type, otp => otp.Ignore());
            CreateMap<Word, WordDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Text : null));

            CreateMap<WordTypeCreateDto, WordType>();
            CreateMap<WordType, WordTypeDto>();
        }
    }
}