using Abstractions.Models;

namespace Abstractions.IRepositories
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<PlaceItem>> GetAsync();

        Task<IEnumerable<PlaceItem>> GetPlacesAsync();
    }
}
