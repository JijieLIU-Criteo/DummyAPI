using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoot()
        {
            var response = new
            {
                message = "Hello world",
            };
            return Ok(response);
        }
    }
}
