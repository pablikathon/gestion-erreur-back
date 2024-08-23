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
        public IQueryable<ServerEntity> GetServers()
        {
            return _context.Server.AsQueryable();
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

        public async Task<bool> UpdateAsync(ServerEntity serverEntity)
        {
            var s = _context.Server.Find(serverEntity.Id);
            if (s != null)
            {
                s.Title = serverEntity.Title;
                s.UpdatedAt = serverEntity.UpdatedAt;
                s.StopHost = serverEntity.StopHost;
                s.HostedSince = serverEntity.HostedSince;
                s.Cost = serverEntity.Cost;
                s.IsActive = serverEntity.IsActive;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

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