using Persist.Entities;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface ICustomerHaveLicenceToService
    {
        PaginationResponse<CustomerHaveLicenceToApplicationEntity> GetAll(GenericQueryParameter queryParameters);

        Task<CustomerHaveLicenceToApplicationEntity> AddAsync(
            CreateCustomerHasLicenceToRequest createCustomerHasLicenceToRequest);

        Task<Boolean> UpdateAsync(UpdateCustomerHasLicenceRequest updateApplicationDeployed);
        Task<Boolean> DeleteAsync(string id_application, string id_server);
    }
}