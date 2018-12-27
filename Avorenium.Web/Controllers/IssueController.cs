using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Avorenium.Web.Controllers
{
    [Route("[controller]")]
    public class IssuesController : BaseController
    {
        private readonly IIssuesApplicationService issuesApplicationService;

        public IssuesController(
            IIssuesApplicationService issueApplicationService) 
        {
            this.issuesApplicationService = issueApplicationService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(IssueCreateDto issueCreateDto)
        {
            var result = await issuesApplicationService.Register(issueCreateDto);

            return HandleResult(result);
        }
    }
}