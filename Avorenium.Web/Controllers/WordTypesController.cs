using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Microsoft.AspNetCore.Mvc;

namespace Avorenium.Web.Controllers
{
    [Route("api/[controller]")]
    public class WordTypesController : BaseController
    {
        private readonly IWordTypesApplicationService wordTypesApplicationService;

        public WordTypesController(
            IWordTypesApplicationService wordTypesApplicationService)
        {
            this.wordTypesApplicationService = wordTypesApplicationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ViewAsync()
        {
            var result = await wordTypesApplicationService.ViewAsync();

            return HandleResult(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody]WordTypeCreateDto wordTypeCreateDto)
        {
            var result = await wordTypesApplicationService.CreateAsync(wordTypeCreateDto);

            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {

            var result = await wordTypesApplicationService.DeleteAsync(id);

            return HandleResult(result);
        }
    }
}