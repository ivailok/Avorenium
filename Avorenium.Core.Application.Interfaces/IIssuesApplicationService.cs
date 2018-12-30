using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Entities.Results;

namespace Avorenium.Core.Application.Interfaces
{
    public interface IIssuesApplicationService
    {
        Task<IApplicationResult<List<IssueDto>, Enum>> ViewAsync();

        Task<IApplicationResult<IssueDto, Enum>> RegisterAsync(IssueCreateDto issueCreateDto);
    }
}
