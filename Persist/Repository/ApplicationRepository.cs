using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;
        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }
        public  IQueryable<ApplicationEntity> GetApplications()
        {
            return  _context.Application.AsQueryable();
        }

        public async Task<ApplicationEntity?> GetByIdAsync(string id)
        {
            return await _context.Application.FindAsync(id);
        }

        public async Task<ApplicationEntity> AddAsync(ApplicationEntity applicationEntity)
        {
            _context.Application.Add(applicationEntity);
            await _context.SaveChangesAsync();
            return applicationEntity;
        }

        public async Task<Boolean> UpdateAsync(ApplicationEntity applicationEntity)
        {
            var a = _context.Application.Find(applicationEntity.Id);
            if (a != null)
            {   
                a.Title = applicationEntity.Title;
                a.UpdatedAt = applicationEntity.UpdatedAt;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            ApplicationEntity? application = await _context.Application.FindAsync(id);
            if (application != null)
            {
                _context.Application.Remove(application);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}