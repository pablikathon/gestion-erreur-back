using Persist.Entities.BaseTable;

namespace Repositories
{
    public interface IErrorRepository
    {
        IQueryable<ErrorEntity> GetAllAsync();
        Task<bool> AddAsync(ErrorEntity errorEntity);
        Task<Boolean> DeleteAsync(string idErreur);
    }
}