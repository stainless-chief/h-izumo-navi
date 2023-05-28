using Abstractions.Models;

namespace Abstractions.IServices
{
    public interface IPredictor
    {
        public Task<IEnumerable<HeatZone>> PredictAsync(string code);
    }
}
