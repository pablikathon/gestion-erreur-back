
using Services.Model;

namespace Services
{
    public interface ISpotterService
    {
        Task<IEnumerable<Spotter>> GetAllSpottersAsync();
        Task<Spotter> GetSpotterByIdAsync(string id);
        Task<Spotter> AddSpotterAsync(Spotter spotter);
        Task<Spotter> UpdateSpotterAsync(Spotter spotter,string id);
        Task<Boolean> DeleteSpotterAsync(string id);
    }
}
