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

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ViewIssuesAsync()
        {
            var result = await issuesApplicationService.ViewIssuesAsync();

            return HandleResult(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> RegisterAsync([FromBody]IssueCreateDto issueCreateDto)
        {
            var result = await issuesApplicationService.RegisterAsync(issueCreateDto);

            return HandleResult(result);
        }
    }
}