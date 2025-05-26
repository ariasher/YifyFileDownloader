using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using YifyApi.Models.Transit.Request;
using YifyApi.Models.Transit.Response.Contracts;
using YifyApi.Utilities.Helpers;
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
        public async Task<IActionResult> MoviesList([FromQuery] BaseRequestDTO request)
        {
            IResponseDTO response;

            try
            {
                // TODO Validation
                var moviesList = await _helper.GetMovies(request);

                if (moviesList == null)
                {
                    response = ResponseHelper.GetErrorResponse("No record found.");
                    return BadRequest(response);
                }

                string message = moviesList.Count() > 0 ? "OK" : "No record found.";
                response = ResponseHelper.GetSuccessResponse(message, moviesList);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = ResponseHelper.GetErrorResponse("An error occurred.");
                // TODO Log
                return BadRequest(response);
            }
            
        }

    }
}
