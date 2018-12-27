using AutoMapper;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto;

namespace Avorenium.Infrastructure.Mapper.Profiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueCreateDto, Issue>();
            CreateMap<Issue, IssueDto>();
        }
    }
}