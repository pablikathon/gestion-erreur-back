using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public PaginationResponse<CustomerEntity> GetCustomers(QueryParameters queryParameters)
        {
            var query = _customerRepository.GetAllAsync();
            query = TextSearchQuery(queryParameters, query);
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = SortQuery(queryParameters, query);
            query = query.Pagination(queryParameters.Pagination);
            var result = query.ToList();
            return new PaginationResponse<CustomerEntity>(result, result.Count, queryParameters.Pagination.PageNumber,
                queryParameters.Pagination.PageSize);
        }

        protected static IQueryable<CustomerEntity> TextSearchQuery(QueryParameters queryParameters,
            IQueryable<CustomerEntity> query)
        {
            if (queryParameters.SearchParam != null)
                if (!String.IsNullOrEmpty(queryParameters.SearchParam.SearchTerm) &&
                    !String.IsNullOrWhiteSpace(queryParameters.SearchParam.SearchTerm))
                {
                    switch (queryParameters.SearchParam.SearchColumn)
                    {
                        case nameof(CustomerEntity.Title):
                            query = query.Where(a => a.Title.ToLower().Contains(queryParameters.SearchParam.SearchTerm.ToLower()));
                            break;
                        case nameof(CustomerEntity.FiscalIdentification):
                            query = query.Where(a =>
                                a.FiscalIdentification.ToLower().Contains(queryParameters.SearchParam.SearchTerm.ToLower()));
                            break;
                        default:
                            throw new ArgumentException("Bad column name");
                    }
                }

            return query;
        }



        protected static IQueryable<CustomerEntity> SortQuery(QueryParameters queryParameters,
            IQueryable<CustomerEntity> query)
        {
            if (!String.IsNullOrEmpty(queryParameters.Sort.SortBy) &&
                !String.IsNullOrWhiteSpace(queryParameters.Sort.SortBy))
            {
                switch (queryParameters.Sort.SortBy)
                {
                    case nameof(CustomerEntity.Title):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.Title)
                            : query.OrderByDescending(a => a.Title);
                        break;
                    case nameof(CustomerEntity.CreatedAt):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.CreatedAt)
                            : query.OrderByDescending(a => a.CreatedAt);
                        break;
                    case nameof(CustomerEntity.UpdatedAt):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.UpdatedAt)
                            : query.OrderByDescending(a => a.UpdatedAt);
                        break;
                    case nameof(CustomerEntity.LastInteraction):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.LastInteraction)
                            : query.OrderByDescending(a => a.LastInteraction);
                        break;
                    case nameof(CustomerEntity.FiscalIdentification):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.FiscalIdentification)
                            : query.OrderByDescending(a => a.FiscalIdentification);
                        break;
                    default:
                        throw new ArgumentException("Bad sort column  name");
                }
            }

            return query;
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
    }
}