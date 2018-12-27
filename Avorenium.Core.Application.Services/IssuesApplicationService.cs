using System;
using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Core.Application.Services
{
    public class IssuesApplicationService : BaseApplicationService, IIssuesApplicationService
    {
        private readonly IMapperService mapperService;

        public IssuesApplicationService(
            IMapperService mapperService)
        {
            this.mapperService = mapperService;
        }

        public async Task<IApplicationResult<IssueDto, Enum>> Register(IssueCreateDto issueCreateDto)
        {
            if (IsInvalidRequest(issueCreateDto, out IApplicationResult<IssueDto, Enum> result))
            {
                return result;
            }

            var issue = mapperService.Map<Issue>(issueCreateDto);

            var issueDto = mapperService.Map<IssueDto>(issue);

            return new ValueResult<IssueDto, Enum>(StatusEnum.EntityCreated, issueDto);
        }
    }
}
