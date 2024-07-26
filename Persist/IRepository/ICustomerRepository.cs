using Persist.Entities;

namespace Repositories
{
    public interface ICustomerRepository 
    {
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        Task<CustomerEntity> GetByIdAsync(string id);
        Task<CustomerEntity> AddAsync(CustomerEntity application);
        Task<CustomerEntity>UpdateAsync(CustomerEntity application);
        Task<Boolean> DeleteAsync(string id);
    }
}
