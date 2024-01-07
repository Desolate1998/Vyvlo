using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController(ILogger<HealthCheckController> logger) : Controller
    {
        [HttpGet("Echo")]
        public IActionResult Echo()
        {
            logger.LogInformation($"Received echo request at {DateTime.UtcNow}");
            return Ok("System is online");
        }

        [Authorize]
        [HttpGet("EchoAuth")]
        public IActionResult EchoAuth()
        {
            logger.LogInformation($"Received echo request at {DateTime.UtcNow}");
            return Ok("System is online");
        }
    }
}
