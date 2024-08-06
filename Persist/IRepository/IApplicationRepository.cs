using Persist.Entities;

namespace Repositories
{
    public interface IApplicationRepository 
    {
        IQueryable<ApplicationEntity> GetApplications();
        Task<ApplicationEntity> GetByIdAsync(string id);
        Task<ApplicationEntity> AddAsync(ApplicationEntity application);
        Task<ApplicationEntity>UpdateAsync(ApplicationEntity application);
        Task<Boolean> DeleteAsync(string id);
    }
}
