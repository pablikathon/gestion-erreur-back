using AutoMapper;
using Persist;
using Persist.Entities.BaseTable;
using Repositories;
using Ressources.DefaultValue.Event;
using Services.Extension;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        private readonly AppDbContext _context;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, AppDbContext context)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _context = context;
        }

        public PaginationResponse<CustomerEntity> GetCustomers(QueryParameters queryParameters)
        {
            var query = _customerRepository.GetAllAsync();
            if (queryParameters.SearchParam != null)
                query = query.TextSearch(queryParameters.SearchParam);
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.SortBy(queryParameters.Sort);
            query = query.Pagination(queryParameters.Pagination);
            var result = query.ToList();
            return new PaginationResponse<CustomerEntity>(result, result.Count, queryParameters.Pagination.PageNumber,
                queryParameters.Pagination.PageSize);
        }


        public async Task<CustomerEntity> CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            var CustomerEntity = _mapper.Map<CustomerEntity>(createCustomerRequest);
            return await _customerRepository.AddAsync(CustomerEntity);
        }

        public async Task<Boolean> UpdateCustomer(UpdateCustomerRequest updateApplicationRequest)
        {
            return await _customerRepository.UpdateAsync(_mapper.Map<CustomerEntity>(updateApplicationRequest));
        }

        public async Task<Boolean> DeleteApplication(string id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public PaginationResponse<ErrorForCustommerStatsResponse> GetErrorsForClientStats(
            QueryParameters queryParameters)
        {
            var query = _context.Customer.Select(custommer => new ErrorForCustommerStatsResponse
            {
                custommerId = custommer.Id,
                CustommerTitle = custommer.Title,
                CustomerFiscalIdentification = custommer.FiscalIdentification,
                nberrorSolved = _context.Error.Where(e => e.Application.CustomerHaveLicenceToApplication
                        .Any(chlta => chlta.CustomerId.Equals(custommer.Id)
                                      &&
                                      e.StatusId == ErrorStatusConstantId.UnresolvedStatus))
                    .Count(),
                nbErrorUnresolved = _context.Error.Where(e => e.Application.CustomerHaveLicenceToApplication
                        .Any(chlta => chlta.CustomerId.Equals(custommer.Id)
                                      &&
                                      e.StatusId != ErrorStatusConstantId.UnresolvedStatus))
                    .Count(),
            });

            query = query.SortBy(queryParameters.Sort);
            query = query.Pagination(queryParameters.Pagination);
            var result = query.ToList();

            return new PaginationResponse<ErrorForCustommerStatsResponse>(result, result.Count,
                queryParameters.Pagination.PageNumber,
                queryParameters.Pagination.PageSize);
        }



    }
}