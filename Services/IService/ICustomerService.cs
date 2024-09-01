using Persist.Entities;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface ICustomerService
    {
        PaginationResponse<CustomerEntity> GetCustomers(QueryParameters queryParameters);
        public IQueryable<ErrorForCustommerStatsResponse> GetErrorsForClientStats();

        Task<CustomerEntity> CreateCustomer(CreateCustomerRequest createCustomerRequest);
        Task<Boolean> UpdateCustomer(UpdateCustomerRequest UpdateApplicationRequest);
        Task<Boolean> DeleteApplication(string id);
    }
}