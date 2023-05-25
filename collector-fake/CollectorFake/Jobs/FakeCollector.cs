using CollectorFake.Models;
using System.Text;
using System.Text.Json;

namespace CollectorFake.Jobs
{
    public sealed class FakeCollector : BackgroundService
    {
        private readonly string _name;
        private readonly TimeSpan _delay;        
        private readonly HttpClient _client;
        private readonly int _latitudeMin;
        private readonly int _latitudeMax;
        private readonly int _longitudeMin;
        private readonly int _longitudeMax;
        private readonly int _maxBatchSize;
        private readonly int _minBatchSize;
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

            _name = configuration.GetSection("SourceName").Get<string>()!;

            _latitudeMin = configuration.GetSection("Generator:LatitudeMin").Get<int>();
            _latitudeMax = configuration.GetSection("Generator:LatitudeMax").Get<int>();
            _longitudeMin = configuration.GetSection("Generator:LongitudeMin").Get<int>();
            _longitudeMax = configuration.GetSection("Generator:LongitudeMax").Get<int>();

            _maxBatchSize = configuration.GetSection("Generator:MaxBatchSize").Get<int>();
            _minBatchSize = configuration.GetSection("Generator:MinBatchSize").Get<int>();

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

            // Noise
            for (int i = 0; i < rnd.Next(0, _minBatchSize); i++)
            {
                hits.Add(new Hit
                {
                    Source = _name,
                    PersonId = "fake-person",
                    Latitude = (rnd.Next(_latitudeMin, _latitudeMax) / 1000000.0),
                    Longitude = (rnd.Next(_longitudeMin, _longitudeMax) / 1000000.0),
                });
            }

            // places
            var length = rnd.Next(_minBatchSize, _maxBatchSize);
            for (int i = 0; i < length; i++)
            {
                var place = GetPlaces()[rnd.Next(0, GetPlaces().Count - 1)];


                hits.Add(new Hit
                {
                     Source = _name,
                     PersonId = "fake-person",
                     Latitude = place.Item2,
                     Longitude = place.Item1,
                });
            }

            return hits;
        }

        private static List<(double, double)> GetPlaces()
        {
            return new List<(double, double)>
            {
                //Lat, long

                //Shimane Museum of Ancient Izumo
                (35.39888959627746, 132.6886550533022),

                //Izumo Hinomisaki Lighthouse
                (35.433729250646685, 132.62933943261814),

                //Hinomisaki Shrine
                (35.42954401217566, 132.62952833436685),

                //Inasa Beach
                (35.40016907071431, 132.67236129865637),

                //Susa Shrine
                (35.23460317055524, 132.73696922711596),

                //Izumotaisha mae Station
                (35.3935306428574, 132.6870381757819),

                //Former Taisha Station
                (35.38664283199816, 132.69028922291457),

                //Michi-no-Eki Kirara Taki
                (35.29066588238849, 132.63240761228602),

                //Shimane Winery
                (35.39602157900597, 132.71140410555083),

                //Izumo Enmusubi Airport 
                (35.41360729021943, 132.8878918189998),

                //Izumoshi Station
                (35.36081880718673, 132.75679555793602),

                //Watanabe Liquor Store
                (35.356749801725435, 132.7315762071781),

                //Lakeside Hot Spring Hotel Kunibiki 
                (35.32421721363435, 132.67696064990585),

                //Inari Shrine
                (35.390253986131505, 132.7409721847641),
            };
        }

        private async Task Send(IEnumerable<Hit> hits)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(hits),Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("save", jsonContent);
                
                var ss = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"{response.StatusCode}{Environment.NewLine}");
                Console.WriteLine($"{ss}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

    }
}
