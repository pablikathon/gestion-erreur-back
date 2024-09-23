using Persist.Entities.BaseTable;

namespace Repositories
{
    public interface IServerRepository
    {
        IQueryable<ServerEntity> GetServers();
        Task<ServerEntity?> GetByIdAsync(string id);
        Task<ServerEntity> AddAsync(ServerEntity serveur);
        Task<Boolean> UpdateAsync(ServerEntity serveur);
        Task<Boolean> DeleteAsync(string id);
    }
}