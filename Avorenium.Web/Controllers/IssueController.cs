using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Avorenium.Web.Controllers
{
    [Route("[controller]")]
    public class IssueController : BaseController
    {
        private readonly IIssueApplicationService issueApplicationService;

        public IssueController(
            IIssueApplicationService issueApplicationService) 
        {
            this.issueApplicationService = issueApplicationService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(IssueCreateDto issueCreateDto)
        {
            var result = await issueApplicationService.Register(issueCreateDto);

            return HandleResult(result);
        }
    }
}