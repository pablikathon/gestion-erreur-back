using Persist.Entities;

namespace Repositories
{
    public interface IEntryRepository 
    {
        Task<IEnumerable<EntryEntity>> GetAllAsync();
        Task<EntryEntity> GetByIdAsync(string id);
        Task<EntryEntity> AddAsync(EntryEntity book);
        Task<EntryEntity>UpdateAsync(EntryEntity book);
        Task<Boolean> DeleteAsync(string id);
    }
}
