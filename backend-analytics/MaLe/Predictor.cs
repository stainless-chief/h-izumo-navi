using Abstractions;
using Abstractions.IRepositories;
using Abstractions.IServices;
using Abstractions.Map;
using Abstractions.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Runtime;
using System.Numerics;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaLe
{
    public class Predictor : IPredictor
    {
        private readonly IHeatZoneRepository _heatZoneRepository;

        public Predictor(IHeatZoneRepository heatZoneRepository)
        {
            _heatZoneRepository = heatZoneRepository;
        }


        public async Task<IEnumerable<HeatZone>> PredictAsync(string code)
        {
            //try
            //{
            //    var mlContext = new MLContext();

            //    var data = await _heatZoneRepository.GetAsync(new List<string> { "Fake_Twitter" });
            //    var dirtyData = data.Select(x => new HeatZoneData(x)).ToList();

            //    var ss = new StringBuilder();

            //    foreach (var item in dirtyData)
            //    {
            //        ss.Append($"{item.X},{item.Y},{item.Hits}{Environment.NewLine}");
            //    }

            //    File.WriteAllText(@"C:\Develop\h-izumo-navi\1.txt", ss.ToString());

            //    IDataView trainingData = mlContext.Data.LoadFromEnumerable(dirtyData);

            //    // 2. Create pipeline
            //    var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "X", "Y" })
            //        .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Hits", maximumNumberOfIterations: 100));

            //    // 3. Train model
            //    var model = pipeline.Fit(trainingData);

            var result = new List<HeatZone>();
            foreach (var item in MapGenerator.CreateIzumo())
            {
                //Load sample data
                var sampleData = new MLModel1.ModelInput()
                {
                    X = (float)item.Coordinates.FirstOrDefault().X,
                    Y = (float)item.Coordinates.FirstOrDefault().Y,
                };

                //Load model and predict output
                var prediction = MLModel1.Predict(sampleData);
                
                result.Add(new HeatZone
                {
                    Coordinates = item.Coordinates,
                    HitStatistics = new Dictionary<string, int>()
                        {
                            { "ML", Convert.ToInt32(prediction.Score)}
                        },
                    Temperature = Convert.ToInt32(prediction.Score),
                });
            }

            NormalizeHeat(result);
            return result;
            //}
            //catch (Exception ex) 
            //{
            //    throw;
            //}
        }

        private static void NormalizeHeat(IEnumerable<HeatZone> zones)
        {
            var maxTemp = zones.Max(x => x.Temperature);

            foreach (var item in zones)
            {
                item.Temperature = RoundOff(item.Temperature * 100d / maxTemp);
            }
        }

        public static int RoundOff(double i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }
    }

    public class Prediction
    {
        [ColumnName("Score")]
        public float Hits { get; set; }

    }

    public class HeatZoneData
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Hits { get;set; }

        public HeatZoneData(HeatZone zone) 
        { 
            Hits = zone.HitStatistics.Select(x => x.Value).Sum();

            X = (float)zone.Coordinates.First().X;
            Y = (float)zone.Coordinates.First().Y;

        }
    }
}