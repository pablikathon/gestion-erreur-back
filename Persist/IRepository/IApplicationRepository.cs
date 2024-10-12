using Persist.Entities.Application;

namespace Repositories
{
    public interface IApplicationRepository
    {
        IQueryable<ApplicationEntity> GetApplications();
        Task<ApplicationEntity?> GetByIdAsync(string id);
        Task<ApplicationEntity> AddAsync(ApplicationEntity application);
        Task<Boolean> UpdateAsync(ApplicationEntity application);
        Task<Boolean> DeleteAsync(string id);
    }
}