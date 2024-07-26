using Persist.Entities;

namespace Repositories
{
    public interface IServerRepository 
    {
        Task<IEnumerable<ServerEntity>> GetAllAsync();
        Task<ServerEntity> GetByIdAsync(string id);
        Task<ServerEntity> AddAsync(ServerEntity serveur);
        Task<ServerEntity>UpdateAsync(ServerEntity serveur);
        Task<Boolean> DeleteAsync(string id);
    }
}
