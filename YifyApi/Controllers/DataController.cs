using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YifyApi.Models.Transit.Request;
using YifyApi.Utilities.Helpers.ControllerHelpers;

namespace YifyApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly DataControllerHelper _helper;
        private readonly ILogger _logger;

        public DataController(DataControllerHelper helper)//, ILogger logger)
        {
            _helper = helper;
            //_logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        //[ApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok("Hey");
        }

        [HttpGet]
        [Route("Movies")]
        public async Task<IActionResult> MoviesList([FromQuery]BaseRequestDTO request)
        {
            // TODO Validation
            var moviesList = await _helper.GetMovies(request);

            return Ok(moviesList);
        }
    }
}
