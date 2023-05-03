using Microsoft.AspNetCore.Mvc;
using Security;
using Security.Models;

namespace CollectorFake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly Supervisor _supervisor = new();

        [HttpGet("ping")]
        public ExecutionResult<string> Get()
        {
            var result = _supervisor.SafeExecute
            (
                () => "pong"
            );

            return result;
        }
    }
}
