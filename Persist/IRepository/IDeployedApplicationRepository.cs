using Persist.Entities;

namespace Repositories
{
    public interface IDeployedApplicationRepository 
    {
        Task<IQueryable<DeployedApplicationEntity>> GetAllAsync();
        Task<DeployedApplicationEntity> GetByIdAsync(string idServer,string idApplication,string idClient);
        Task<DeployedApplicationEntity> AddAsync(DeployedApplicationEntity application);
        Task<Boolean> DeleteAsync(string idServer,string idApplication,string idClient);
    }
}
