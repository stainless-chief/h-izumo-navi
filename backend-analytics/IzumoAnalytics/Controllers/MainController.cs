using Abstractions.IRepositories;
using Abstractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;
using Security.Models;

namespace IzumoAnalytics.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("analytics/v{version:apiVersion}/")]
    public class MainController : ControllerBase
    {
        private readonly Supervisor _supervisor = new Supervisor();
        private readonly IHeatZoneRepository _heatZoneRepository;
        private readonly ISourceRepository _sourceRepository;

        public MainController(IHeatZoneRepository heatZoneRepository, ISourceRepository sourceRepository)
        {
            _heatZoneRepository = heatZoneRepository;
            _sourceRepository = sourceRepository;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("ping")]
        public ActionResult<ExecutionResult<string>> Ping()
        {
            var result = _supervisor.SafeExecute
            (
                () => "pong"
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("source/all")]
        public async Task<ActionResult<ExecutionResult<IEnumerable<Source>>>> GetCategoriesAsync()
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _sourceRepository.GetAsync()
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("heatzone")]
        public async Task<ActionResult<ExecutionResult<IEnumerable<HeatZone>>>> GetHeatZones([FromBody]IEnumerable<string> sourceCode)
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _heatZoneRepository.GetAsync(sourceCode)
            );

            return result;
        }
    }
}