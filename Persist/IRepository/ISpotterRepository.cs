using Persist.Entities;

namespace Repositories
{
    public interface ISpotterRepository 
    {
        Task<IEnumerable<SpotterEntity>> GetAllAsync();
        Task<SpotterEntity> GetByIdAsync(string id);
        Task<SpotterEntity> AddAsync(SpotterEntity book);
        Task<SpotterEntity>UpdateAsync(SpotterEntity book);
        Task<Boolean> DeleteAsync(string id);
    }
}
