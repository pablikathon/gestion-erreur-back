using Persist;
using Persist.Entities;
using Persist.Entities.BaseTable;

namespace Repositories
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly AppDbContext _context;

        public ErrorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ErrorEntity> GetAllAsync()
        {
            return _context.Error.AsQueryable();
        }

        public async Task<bool> AddAsync(ErrorEntity errorEntity)
        {
            try
            {
                _context.Error.Add(errorEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception )
            {
                throw;
            }
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            ErrorEntity? errorEntity = await _context.Error.FindAsync(id);
            if (errorEntity != null)
            {
                _context.Error.Remove(errorEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}