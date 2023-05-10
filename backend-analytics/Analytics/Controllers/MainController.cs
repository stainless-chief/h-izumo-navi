using Abstractions.IRepositories;
using Abstractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;
using Security.Models;

namespace Analytics.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("analytics/v{version:apiVersion}/")]
    public class MainController : ControllerBase
    {
        private readonly Supervisor _supervisor = new();
        private readonly IHeatZoneRepository _heatZoneRepository;
        private readonly IHitRepository _hitRepository;
        private readonly ISourceRepository _sourceRepository;
        private readonly IStatisticsRepository _statisticsRepository;

        public MainController(
            IHeatZoneRepository heatZoneRepository,
            IHitRepository hitRepository,
            ISourceRepository sourceRepository,
            IStatisticsRepository statisticsRepository
            )
        {
            _heatZoneRepository = heatZoneRepository;
            _hitRepository = hitRepository;
            _sourceRepository = sourceRepository;
            _statisticsRepository = statisticsRepository;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("ping")]
        public ExecutionResult<string> Ping()
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
        public async Task<ExecutionResult<IEnumerable<Source>>> GetSources()
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _sourceRepository.GetAsync(true)
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpPost("heatzone")]
        public async Task<ExecutionResult<IEnumerable<HeatZone>>> GetHeatZones([FromBody] IEnumerable<string> sourceCode)
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _heatZoneRepository.GetAsync(sourceCode)
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpPost("save")]
        public async Task<ExecutionResult<bool>> Save([FromBody] Hit[] hits)
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _hitRepository.SaveAsync(hits)
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("statistics")]
        public async Task<ExecutionResult<IEnumerable<StatisticItem>>> GetStatistics()
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _statisticsRepository.GetAsync()
            );

            return result;
        }
    }
}
