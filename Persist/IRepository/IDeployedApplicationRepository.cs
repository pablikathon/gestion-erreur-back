using Persist.Entities;

namespace Repositories
{
    public interface IDeployedApplicationRepository 
    {
        Task<IEnumerable<DeployedApplicationEntity>> GetAllDeployedApplicationsAsync();
        Task<DeployedApplicationEntity> GetByIdAsync(string id);
        Task<DeployedApplicationEntity> AddAsync(ApplicationEntity application);
        Task<DeployedApplicationEntity>UpdateAsync(ApplicationEntity application);
        Task<Boolean> DeleteAsync(string id);
    }
}
