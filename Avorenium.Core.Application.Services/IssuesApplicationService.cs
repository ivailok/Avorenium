using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Data;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Core.Application.Services
{
    public class IssuesApplicationService : BaseApplicationService, IIssuesApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IIssuesDomainService issuesDomainService;
        private readonly IWordsDomainService wordsDomainService;
        private readonly ITermsDomainService termsDomainService;
        private readonly IMapperService mapperService;

        public IssuesApplicationService(
            IUnitOfWork unitOfWork,
            IIssuesDomainService issuesDomainService,
            IWordsDomainService wordsDomainService,
            ITermsDomainService termsDomainService,
            IMapperService mapperService)
        {
            this.unitOfWork = unitOfWork;
            this.issuesDomainService = issuesDomainService;
            this.wordsDomainService = wordsDomainService;
            this.termsDomainService = termsDomainService;
            this.mapperService = mapperService;
        }

        public async Task<IApplicationResult<List<IssueDto>, Enum>> ViewAsync()
        {
            var issueDtos = await issuesDomainService.GetListAsync();

            return new ValueResult<List<IssueDto>, Enum>(StatusEnum.EntityRetrieved, issueDtos);
        }

        public async Task<IApplicationResult<IssueDto, Enum>> RegisterAsync(IssueCreateDto issueCreateDto)
        {
            if (IsInvalidRequest(issueCreateDto, out IApplicationResult<IssueDto, Enum> result))
            {
                return result;
            }

            var issue = issuesDomainService.Create(issueCreateDto);

            var separators = (await wordsDomainService.GetListAsync(3)).Select(x => x.Text).ToList();
            var clutter = (await wordsDomainService.GetListAsync(4)).Select(x => x.Text).ToList();
            var meaningfulTitleWords = termsDomainService.GetFilteredTerms(issue.Title, separators, clutter);
            var meaningfulDescriptionWords = termsDomainService.GetFilteredTerms(issue.Description, separators, clutter);
            var allMeaningfulWords = meaningfulTitleWords.Concat(meaningfulDescriptionWords).Select(x => x.ToLower()).Distinct().ToList();
            await wordsDomainService.SaveCollectionAsync(allMeaningfulWords, issue);

            await unitOfWork.CompleteAsync();

            var issueDto = mapperService.Map<IssueDto>(issue);

            return new ValueResult<IssueDto, Enum>(StatusEnum.EntityCreated, issueDto);
        }
    }
}
