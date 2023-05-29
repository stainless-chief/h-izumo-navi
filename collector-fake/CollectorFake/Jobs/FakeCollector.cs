using CollectorFake.Models;
using System.Collections.Generic;
using System;
using System.Text;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.SignalR;

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

        private readonly int _maxHitMonth = 1000;
        private int _currentMonth = 1;
        private int _curretMonthHits = 0;


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
                    var rnd = new Random();
                    var data = GenerateHits().Take(_maxHitMonth + rnd.Next(463));

                    Console.WriteLine($"Generate {data.Count()} values");
                    await Send(data);

                    _curretMonthHits += data.Count();
                    if (_curretMonthHits > _maxHitMonth)
                    {
                        _curretMonthHits = 0;
                        _currentMonth++;

                        if (_currentMonth == 7) { return; }

                        if (_currentMonth == 12)
                        {
                            _currentMonth = 1;
                        }
                    }

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

            // group
            var groupSize = rnd.Next(10, 30);
            
            // arrival
            var hub = GetHub();
            for (int i = 0; i <= groupSize; i++)
            {
                hits.Add(new Hit
                {
                    Source = _name,
                    PersonId = "fake-person",
                    Latitude = hub.Item1,
                    Longitude = hub.Item2,
                    Date = new DateTime(2023, _currentMonth, 1),
                });
            }

            // visit
            for (int i = 0; i <= groupSize; i++)
            {
                var places = GetPlaces().OrderBy(x => rnd.Next()).Take(rnd.Next(5, 10));

                for (int plc = 0; plc <= rnd.Next(5, 10); plc++)
                {
                    var place = GetPlaces()[rnd.Next(GetPlaces().Count)];

                    {
                        hits.Add(new Hit
                        {
                            Source = _name,
                            PersonId = "fake-person",
                            Latitude = place.Item1,
                            Longitude = place.Item2,
                            Date = new DateTime(2023, _currentMonth, 1),
                        });

                        //noise
                        //if (rnd.Next(0, 1) == 1)
                        {
                            var noiseLength = rnd.Next(50, 250);
                            for (var noise = 0; noise < noiseLength; noise++)
                            {
                                hits.Add(new Hit
                                {
                                    Source = _name,
                                    PersonId = "fake-person",
                                    Latitude = place.Item1 + rnd.Next(40000, 90000) / 100000,
                                    Longitude = place.Item2 + rnd.Next(40000, 50000) / 100000,
                                    Date = new DateTime(2023, _currentMonth, 1),
                                });
                            }
                        }


                        //pure noise
                        if (rnd.Next(0, 1) == 1)
                        {
                            var pureNoiseLength = rnd.Next(10, 100);
                            for (var noise = 0; noise < pureNoiseLength; noise++)
                            {
                                hits.Add(new Hit
                                {
                                    Source = _name,
                                    PersonId = "fake-person",
                                    Latitude = (rnd.Next(_latitudeMin, _latitudeMax) / 1000000.0),
                                    Longitude = (rnd.Next(_longitudeMin, _longitudeMax) / 1000000.0),
                                    Date = new DateTime(2023, _currentMonth, 1),
                                });
                            }
                        }
                    }
                }
            }


            return hits;
        }

        public static (double, double) GetHub()
        {
            var rnd = new Random();
            var hubs = new List<(double, double)>
            {
                //Izumo Enmusubi Airport
                (35.41360729021943, 132.8878918189998),

                //Izumoshi Station
                (35.36081880718673, 132.75679555793602),

                 //Izumoshi Station
                (35.36081880718673, 132.75679555793602),

                (35.33500415006196, 132.72205277396878),
            };

            return hubs[rnd.Next(hubs.Count)];
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

                //Izumo Hinomisaki Lighthouse
                (35.433729250646685, 132.62933943261814),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),
                
                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),
                
                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),
                
                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Hinomisaki Jinja
                (35.42954401217566, 132.62952833436685),

                //Inasa Beach
                (35.40016907071431, 132.67236129865637),

                //Susa Jinja
                (35.23460317055524, 132.73696922711596),

                //Izumotaisha mae Station
                (35.3935306428574, 132.6870381757819),

                //Former Taisha Station
                (35.38664283199816, 132.69028922291457),

                //Michi-no-Eki Kirara Taki
                (35.29066588238849, 132.63240761228602),

                //Shimane Winery
                (35.39602157900597, 132.71140410555083),

                //Watanabe Liquor Store
                (35.356749801725435, 132.7315762071781),

                //Lakeside Hot Spring Hotel Kunibiki 
                (35.32421721363435, 132.67696064990585),

                //Inari Jinja
                (35.390253986131505, 132.7409721847641),

                //Inari Jinja
                (35.390253986131505, 132.7409721847641),

                //Inari Jinja
                (35.390253986131505, 132.7409721847641),

                //Inari Jinja
                (35.390253986131505, 132.7409721847641),

                //Uryu Castle Ruins
                (35.43172339707068, 132.63704100800425),
            };
        }

        private async Task Send(IEnumerable<Hit> hits)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(hits),Encoding.UTF8, "application/json");

            try
            {
                await _client.PostAsync("save", jsonContent);                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

    }
}
