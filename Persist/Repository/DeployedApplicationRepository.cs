using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class DeployedApplicationRepository : IDeployedApplicationRepository
    {
        private readonly AppDbContext _context;
        public DeployedApplicationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<DeployedApplicationEntity>> GetAllAsync()
        {
            return  _context.DeployedApplication.AsQueryable();
        }

        public async Task<DeployedApplicationEntity?> GetByIdAsync(string idServer,string idApplication,string idClient)
        {
            return await _context.DeployedApplication.FirstOrDefaultAsync(DeployedApplicationEntity => 
            DeployedApplicationEntity.ServerId == idServer && 
            DeployedApplicationEntity.ApplicationId == idApplication &&
            DeployedApplicationEntity.CustomerId == idClient
            );
        }

        public async Task<DeployedApplicationEntity> AddAsync(DeployedApplicationEntity deployedApplicationEntity)
        {
            _context.DeployedApplication.Add(deployedApplicationEntity);
            await _context.SaveChangesAsync();
            return deployedApplicationEntity;
        }
        public async Task<Boolean> DeleteAsync(string idServer,string idApplication,string idClient)
        {
            DeployedApplicationEntity? deployedApplication = await _context.DeployedApplication.FindAsync(idServer, idApplication, idClient);
            if (deployedApplication != null)
            {
                _context.DeployedApplication.Remove(deployedApplication);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}