using System.Threading.Tasks;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Domain.Entities.Dto.Word;
using Microsoft.AspNetCore.Mvc;

namespace Avorenium.Web.Controllers
{
    [Route("api/[controller]")]
    public class WordsController : BaseController
    {
        private readonly IWordsApplicationService wordsApplicationService;

        public WordsController(
            IWordsApplicationService wordsApplicationService)
        {
            this.wordsApplicationService = wordsApplicationService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ViewAsync()
        {
            var result = await wordsApplicationService.ViewAsync();

            return HandleResult(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody]WordCreateDto wordCreateDto)
        {
            var result = await wordsApplicationService.CreateAsync(wordCreateDto);

            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {

            var result = await wordsApplicationService.DeleteAsync(id);

            return HandleResult(result);
        }
    }
}