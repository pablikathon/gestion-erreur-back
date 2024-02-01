using Services.Model;

namespace Services
{
    public interface IEntrySpotterService
    {
        Task<IEnumerable<EntrySpotter>> GetAllEntrySpotterAsync();
        Task<EntrySpotter> AddEntrySpotterAsync(EntrySpotter EntrySpotter);
        Task<Boolean> DeleteEntrySpotterAsync(EntrySpotter EntrySpotter);
    }
}
