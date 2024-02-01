using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;
namespace Repositories
{
public class EntrySpotterRepository : IEntrySpotterRepository
{
    private readonly AppDbContext _context;

    public EntrySpotterRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<EntrySpotterEntity> AddAsync(EntrySpotterEntity entrySpotter)
    {

        _context.EntrySpotter.Add(entrySpotter);
        await _context.SaveChangesAsync();
        return entrySpotter;
    }

    public async Task<Boolean> DeleteAsync(EntrySpotterEntity entrySpotter)
    {
        EntrySpotterEntity entity = await _context.EntrySpotter.FirstOrDefaultAsync(es => es.Entry.Id == entrySpotter.Entry.Id && es.Spotter.Id == entrySpotter.Entry.Id);

        if (entity != null)
        {
            _context.EntrySpotter.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<EntrySpotterEntity>> GetAllAsync()
    {
        return await _context.EntrySpotter.Include(e =>e.Entry).Include(s=>s.Spotter).ToListAsync();
    }
}

}
