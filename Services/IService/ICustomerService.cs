using Persist.Entities.BaseTable;

using Services.Models.Command;
using Services.Models.Common;

namespace Services
{
    public interface ICustomerService
    {
        PaginationResponse<CustomerEntity> GetCustomers(QueryParameters queryParameters);

        public PaginationResponse<ErrorForCustommerStatsResponseCommand> GetErrorsForClientStats(
            QueryParameters queryParameters);

        Task<CustomerEntity> CreateCustomer(CreateCustomerCommand createCustomerRequest);
        Task<Boolean> UpdateCustomer(UpdateCustomerCommand UpdateCustomerCommand);
        Task<Boolean> DeleteCustomer(string id);
    }
}
