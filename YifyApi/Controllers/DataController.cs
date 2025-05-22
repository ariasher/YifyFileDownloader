using Microsoft.AspNetCore.Mvc;

namespace YifyApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        //[ApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok("Hey");
        }
    }
}
