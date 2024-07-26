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
        public async Task<IEnumerable<ApplicationEntity>> GetAllAsync()
        {
            return await _context.Application.ToListAsync();
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

        public async Task<ApplicationEntity?> UpdateAsync(ApplicationEntity applicationEntity)
        {
            _context.Entry(applicationEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Application.FindAsync(applicationEntity.Id);
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