using System;
using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Core.Application.Services
{
    public class IssuesApplicationService : BaseApplicationService, IIssuesApplicationService
    {
        private readonly IIssuesDomainService issuesDomainService;
        private readonly IMapperService mapperService;

        public IssuesApplicationService(
            IIssuesDomainService issuesDomainService,
            IMapperService mapperService)
        {
            this.issuesDomainService = issuesDomainService;
            this.mapperService = mapperService;
        }

        public async Task<IApplicationResult<IssueDto, Enum>> RegisterAsync(IssueCreateDto issueCreateDto)
        {
            if (IsInvalidRequest(issueCreateDto, out IApplicationResult<IssueDto, Enum> result))
            {
                return result;
            }

            var issueDto = await issuesDomainService.CreateAsync(issueCreateDto);

            return new ValueResult<IssueDto, Enum>(StatusEnum.EntityCreated, issueDto);
        }
    }
}
