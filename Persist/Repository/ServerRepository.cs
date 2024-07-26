using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly AppDbContext _context;
        public ServerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ServerEntity>> GetAllAsync()
        {
            return await _context.Server.ToListAsync();
        }

        public async Task<ServerEntity?> GetByIdAsync(string id)
        {
            return await _context.Server.FindAsync(id);
        }

        public async Task<ServerEntity> AddAsync(ServerEntity serverEntity)
        {
            _context.Server.Add(serverEntity);
            await _context.SaveChangesAsync();
            return serverEntity;
        }

        public async Task<ServerEntity?> UpdateAsync(ServerEntity serverEntity)
        {
            _context.Entry(serverEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Server.FindAsync(serverEntity.Id);
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            ServerEntity? serverEntity = await _context.Server.FindAsync(id);
            if (serverEntity != null)
            {
                _context.Server.Remove(serverEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}