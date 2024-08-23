using Persist.Entities;

namespace Repositories
{
    public interface IApplicationDeployedOnServerRepository
    {
        IQueryable<ApplicationDeployedOnServerEntity> GetAllAsync();
        Task<ApplicationDeployedOnServerEntity?> GetByIdAsync(string idServer, string idApplication);
        Task<ApplicationDeployedOnServerEntity> AddAsync(ApplicationDeployedOnServerEntity application);
        Task<bool> UpdateAsync(ApplicationDeployedOnServerEntity application);

        Task<Boolean> DeleteAsync(string idServer, string idApplication);
    }
}
