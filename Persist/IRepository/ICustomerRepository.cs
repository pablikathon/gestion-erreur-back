using System.Linq.Expressions;
using Persist.Entities;

namespace Repositories
{
    public interface ICustomerRepository
    {
        IQueryable<CustomerEntity> GetAllAsync();
        Task<CustomerEntity?> GetByIdAsync(string id);
        Task<CustomerEntity> AddAsync(CustomerEntity application);
        Task<Boolean> UpdateAsync(CustomerEntity application);
        Task<Boolean> DeleteAsync(string id);
        public IQueryable<ErrorEntity> GetErrorsForACustommer(string idCustommer);
    }
}