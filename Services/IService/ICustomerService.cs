using Persist.Entities.BaseTable;

using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface ICustomerService
    {
        PaginationResponse<CustomerEntity> GetCustomers(QueryParameters queryParameters);

        public PaginationResponse<ErrorForCustommerStatsResponse> GetErrorsForClientStats(
            QueryParameters queryParameters);

        Task<CustomerEntity> CreateCustomer(CreateCustomerCommand createCustomerRequest);
        Task<Boolean> UpdateCustomer(UpdateCustomerCommand UpdateCustomerCommand);
        Task<Boolean> DeleteCustomer(string id);
    }
}
