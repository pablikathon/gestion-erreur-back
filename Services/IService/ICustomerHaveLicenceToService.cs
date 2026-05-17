using Persist.Entities;

using Services.Models.Command;
using Services.Models.Common;

namespace Services
{
    public interface ICustomerHaveLicenceToService
    {
        PaginationResponse<CustomerHaveLicenceToApplicationEntity> GetAll(GenericQueryParameter queryParameters);

        Task<CustomerHaveLicenceToApplicationEntity> AddAsync(
            CreateCustomerHasLicenceToCommand createCustomerHasLicenceToRequest);

        Task<Boolean> UpdateAsync(UpdateCustomerHasLicenceCommand updateCustomerHasLicenceToCommand);
        Task<Boolean> DeleteAsync(string id_application, string id_server);
    }
}
