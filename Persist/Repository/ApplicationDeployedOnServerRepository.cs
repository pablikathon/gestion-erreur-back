using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class ApplicationDeployedOnServerRepository : IApplicationDeployedOnServerRepository
    {
        private readonly AppDbContext _context;
        public ApplicationDeployedOnServerRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<ApplicationDeployedOnServerEntity> GetAllAsync()
        {
            return _context.ApplicationDeployedOnServer
                    .Include(e => e.Server)      
                    .Include(e => e.Customer)    
                    .Include(e => e.Application)
                    .AsQueryable();
        }

        public async Task<ApplicationDeployedOnServerEntity?> GetByIdAsync(string idServer, string idApplication)
        {
            return await _context.ApplicationDeployedOnServer.FirstOrDefaultAsync(DeployedApplicationEntity =>
            DeployedApplicationEntity.ServerId == idServer &&
            DeployedApplicationEntity.ApplicationId == idApplication);
        }

        public async Task<ApplicationDeployedOnServerEntity> AddAsync(ApplicationDeployedOnServerEntity deployedApplicationEntity)
        {
            _context.ApplicationDeployedOnServer.Add(deployedApplicationEntity);
            await _context.SaveChangesAsync();
            await _context.LoadReferencesAsync(deployedApplicationEntity, e => e.Server, e => e.Customer, e => e.Application);
            return deployedApplicationEntity;
        }


        public async Task<Boolean> DeleteAsync(string idServer, string idApplication)
        {
            ApplicationDeployedOnServerEntity? deployedApplication = await _context.ApplicationDeployedOnServer.FindAsync(idServer, idApplication);
            if (deployedApplication != null)
            {
                _context.ApplicationDeployedOnServer.Remove(deployedApplication);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ApplicationDeployedOnServerEntity ApplicationDeployedOnServer)
        {
            var ads = await _context.ApplicationDeployedOnServer.FindAsync(ApplicationDeployedOnServer.ApplicationId, ApplicationDeployedOnServer.CustomerId);
            if (ads != null)
            {
                ads.ApplicationPath = ApplicationDeployedOnServer.ApplicationPath;
                ads.UpdatedAt = ApplicationDeployedOnServer.UpdatedAt;
                ads.IsActive = ApplicationDeployedOnServer.IsActive;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}