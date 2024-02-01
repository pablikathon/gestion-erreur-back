using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class SpotterRepository : ISpotterRepository
    {
        private readonly AppDbContext _context;

        public SpotterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpotterEntity>> GetAllAsync()
        {
            return await _context.Spotter.ToListAsync();
        }

        public async Task<SpotterEntity> GetByIdAsync(string id)
        {
            return await _context.Spotter.FindAsync(id);
        }

        public async Task<SpotterEntity> AddAsync(SpotterEntity spotter)
        {
            _context.Spotter.Add(spotter);
            await _context.SaveChangesAsync();
            return spotter;
        }

        public async Task<SpotterEntity> UpdateAsync(SpotterEntity spotter)
        {
            _context.Entry(spotter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Spotter.FindAsync(spotter.Id);
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            SpotterEntity spotter = await _context.Spotter.FindAsync(id);
            if (spotter != null)
            {
                _context.Spotter.Remove(spotter);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
