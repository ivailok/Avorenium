using System.Collections.Generic;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto;

namespace Avorenium.Core.Domain.Interfaces
{
    public interface IIssuesDomainService
    {
        Task<List<IssueDto>> GetListAsync();

        Task<IssueDto> CreateAsync(IssueCreateDto issueCreateDto);
    }
}