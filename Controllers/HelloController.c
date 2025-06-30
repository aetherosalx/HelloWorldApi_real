using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("api/hello")]
    public class HelloController : ControllerBase
    {
        // Default GET: api/hello
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }

        // GET: api/hello/greet?name=Alex
        [HttpGet("greet")]
        public IActionResult Greet([FromQuery] string name = "guest")
        {
            return Ok($"Hello, {name}!");
        }

        // GET: api/hello/time
        [HttpGet("time")]
        public IActionResult GetTime()
        {
            return Ok($"The current server time is {DateTime.Now:T}");
        }
    }
}