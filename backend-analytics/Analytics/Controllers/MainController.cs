using Abstractions.IRepositories;
using Abstractions.IServices;
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
        private readonly IPlaceRepository _statisticsRepository;
        private readonly IPredictor _predictor;

        public MainController(
            IHeatZoneRepository heatZoneRepository,
            IHitRepository hitRepository,
            ISourceRepository sourceRepository,
            IPlaceRepository statisticsRepository,
            IPredictor predictor
            )
        {
            _heatZoneRepository = heatZoneRepository;
            _hitRepository = hitRepository;
            _sourceRepository = sourceRepository;
            _statisticsRepository = statisticsRepository;
            _predictor = predictor;
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
            Console.WriteLine("incoming");

            var result = await _supervisor.SafeExecuteAsync
            (
                () => _hitRepository.SaveAsync(hits)
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpPost("prediction")]
        public async Task<ExecutionResult<IEnumerable<HeatZone>>> Predict()
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _predictor.PredictAsync("")
            );

            return result;
        }

        [AllowAnonymous]
        [ApiVersion("1.0")]
        [HttpGet("statistics")]
        public async Task<ExecutionResult<IEnumerable<PlaceItem>>> GetStatistics()
        {
            var result = await _supervisor.SafeExecuteAsync
            (
                () => _statisticsRepository.GetAsync()
            );

            return result;
        }
    }
}
