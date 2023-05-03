using CollectorFake.Models;
using System.Text.Json;
using System.Text;

namespace CollectorFake.Jobs
{
    public sealed class FakeCollector : BackgroundService
    {
        private const string _name = "FakeTwitter";
        private readonly TimeSpan _delay;        
        private readonly HttpClient _client;
        private readonly int _latitudeMin;
        private readonly int _latitudeMax;
        private readonly int _longitudeMin;
        private readonly int _longitudeMax;
        private readonly int _maxBatchSize;
        private DateTime _lastJob = DateTime.MinValue;

        public FakeCollector(IConfiguration configuration)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(configuration.GetSection("AnalyticsApi").Get<string>()!)
            };

            _delay = TimeSpan.FromSeconds
            (
                configuration.GetSection("Generator:DelaySeconds").Get<int>()
            );

            _latitudeMin = configuration.GetSection("Generator:LatitudeMin").Get<int>();
            _latitudeMax = configuration.GetSection("Generator:LatitudeMax").Get<int>();
            _longitudeMin = configuration.GetSection("Generator:LongitudeMin").Get<int>();
            _longitudeMax = configuration.GetSection("Generator:LongitudeMax").Get<int>();
            _maxBatchSize = configuration.GetSection("Generator:MaxBatchSize").Get<int>();

            Console.WriteLine($"BaseAddress: {_client.BaseAddress}");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if ((DateTime.UtcNow - _lastJob) > _delay)
                {
                    var data = GenerateHits();

                    Console.WriteLine($"Generate {data.Count()} values");
                    await Send(data);
                    _lastJob = DateTime.UtcNow;
                }
                else
                {
                    await Task.Delay(_delay, stoppingToken);
                }
            }
        }


        private IEnumerable<Hit> GenerateHits()
        {
            var hits = new List<Hit>();
            var rnd = new Random();

            for (int i = 0; i < rnd.Next(10, _maxBatchSize); i++)
            {
                hits.Add(new Hit
                {
                     Source = _name,
                     PersonId = "no-one",
                     Latitude = (rnd.Next(_latitudeMin, _latitudeMax) / 1000000.0),
                     Longitude = (rnd.Next(_longitudeMin, _longitudeMax) / 1000000.0),
                });
            }

            return hits;
        }

        private async Task Send(IEnumerable<Hit> hits)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(hits),Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("save", jsonContent);

                Console.WriteLine($"{response.StatusCode}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }
    }
}
