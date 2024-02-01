using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly AppDbContext _context;

        public EntryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EntryEntity>> GetAllAsync()
        {
            return await _context.Entries.ToListAsync();
        }

        public async Task<EntryEntity> GetByIdAsync(string id)
        {
            return await _context.Entries.FindAsync(id);
        }

        public async Task<EntryEntity> AddAsync(EntryEntity book)
        {
            _context.Entries.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<EntryEntity> UpdateAsync(EntryEntity entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Entries.FindAsync(entry.Id);
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            EntryEntity entry = await _context.Entries.FindAsync(id);
            if (entry != null)
            {
                _context.Entries.Remove(entry);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
