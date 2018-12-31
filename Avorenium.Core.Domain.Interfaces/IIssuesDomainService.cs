using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Data.Dbo;
using Avorenium.Core.Domain.Entities.Dto;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface IIssuesDomainService
    {
        Task<List<IssueDto>> GetListAsync(List<string> filterWords = null);

        Issue Create(IssueCreateDto issueCreateDto);
    }
}