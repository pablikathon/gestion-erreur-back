using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Model;

namespace Services
{
    public interface IEntryService
    {
        Task<IEnumerable<Entry>> GetAllEntrysAsync();
        Task<Entry> GetEntryByIdAsync(string id);
        Task<Entry> AddEntryAsync(Entry entry);
        Task<Entry> UpdateEntryAsync(Entry entry,string id);
        Task<Boolean> DeleteEntryAsync(string id);
    }
}
