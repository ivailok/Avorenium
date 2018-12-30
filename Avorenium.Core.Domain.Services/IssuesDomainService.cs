using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Interfaces.Data;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Core.Domain.Services
{
    public class IssuesDomainService : IIssuesDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IIssuesRepository issuesRepository;
        private readonly IMapperService mapperService;

        public IssuesDomainService(
            IUnitOfWork unitOfWork,
            IIssuesRepository issuesRepository,
            IMapperService mapperService)
        {
            this.unitOfWork = unitOfWork;
            this.issuesRepository = issuesRepository;
            this.mapperService = mapperService;
        }

        public async Task<List<IssueDto>> GetListAsync()
        {
            var issues = await issuesRepository.GetListIncludingWordsAsync();
            var issueDtos = mapperService.Map<List<IssueDto>>(issues);

            return issueDtos;
        }

        public Issue Create(IssueCreateDto issueCreateDto)
        {
            var issue = mapperService.Map<Issue>(issueCreateDto);
            issuesRepository.Add(issue);

            return issue;
        }
    }
}