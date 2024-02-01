using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persist.Entities;

namespace Repositories
{
    public interface IEntrySpotterRepository
    {
        Task<IEnumerable<EntrySpotterEntity>> GetAllAsync();
        Task<EntrySpotterEntity> AddAsync(EntrySpotterEntity entrySpotter);
        Task<Boolean> DeleteAsync(EntrySpotterEntity entrySpotter);
    }
}
