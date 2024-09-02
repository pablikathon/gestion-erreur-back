using Persist.Entities;

namespace Repositories
{
    public interface ICustomerHaveLicenceToApplicationRepository
    {
        IQueryable<CustomerHaveLicenceToApplicationEntity> GetAllAsync();
        Task<CustomerHaveLicenceToApplicationEntity?> GetByIdAsync(string idClient, string idApplication);

        Task<CustomerHaveLicenceToApplicationEntity> AddAsync(
            CustomerHaveLicenceToApplicationEntity CustomerHaveLicenceToApplication);

        Task<Boolean> UpdateAsync(CustomerHaveLicenceToApplicationEntity CustomerHaveLicenceToApplication);

        Task<Boolean> DeleteAsync(string id_client, string idApplication);
    }
}