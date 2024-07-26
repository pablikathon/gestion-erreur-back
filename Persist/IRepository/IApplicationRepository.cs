using Persist.Entities;

namespace Repositories
{
    public interface IApplicationRepository 
    {
        Task<IEnumerable<ApplicationEntity>> GetAllAsync();
        Task<ApplicationEntity> GetByIdAsync(string id);
        Task<ApplicationEntity> AddAsync(ApplicationEntity application);
        Task<ApplicationEntity>UpdateAsync(ApplicationEntity application);
        Task<Boolean> DeleteAsync(string id);
    }
}
