using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<BookEntity> GetByIdAsync(string id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<BookEntity> AddAsync(BookEntity book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<BookEntity> UpdateAsync(BookEntity book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Books.FindAsync(book.Id);
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            BookEntity book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
