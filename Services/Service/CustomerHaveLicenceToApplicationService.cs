using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class CustomerHaveLicenceToApplicationService : ICustomerHaveLicenceToService
    {
        private readonly ICustomerHaveLicenceToApplicationRepository _customerHaveLicenceToApplicationRepository;
        private readonly IMapper _mapper;

        public CustomerHaveLicenceToApplicationService(ICustomerHaveLicenceToApplicationRepository CustomerHaveLicenceToApplicationRepository, IMapper mapper)
        {
            _customerHaveLicenceToApplicationRepository = CustomerHaveLicenceToApplicationRepository;
            _mapper = mapper;
        }

        public Task<bool> DeleteAsync(string idClient, string idApplication)
        {
            return _customerHaveLicenceToApplicationRepository.DeleteAsync(idClient, idApplication);

        }

        public Task<CustomerHaveLicenceToApplicationEntity> AddAsync(CreateCustomerHasLicenceToRequest createCustomerHasLicenceToRequest)
        {
            return _customerHaveLicenceToApplicationRepository.AddAsync(_mapper.Map<CustomerHaveLicenceToApplicationEntity>(createCustomerHasLicenceToRequest));
        }

        public PaginationResponse<CustomerHaveLicenceToApplicationEntity> GetAll(GenericQueryParameter queryParameters)
        {
            var query = _customerHaveLicenceToApplicationRepository.GetAllAsync();
            query = DateSearchQuery(queryParameters, query);
            query = query.Pagination(queryParameters.Pagination);

            var result = query.ToList();
            return new PaginationResponse<CustomerHaveLicenceToApplicationEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);        }


        internal static IQueryable<CustomerHaveLicenceToApplicationEntity> DateSearchQuery(GenericQueryParameter queryParameters,
            IQueryable<CustomerHaveLicenceToApplicationEntity> query)
        {
            if(queryParameters.DateParam != null)
            if (queryParameters.DateParam.StartDate.HasValue && queryParameters.DateParam.EndDate.HasValue)
            {
                switch (queryParameters.DateParam.DateField)
                {
                    case nameof(CustomerHaveLicenceToApplicationEntity.CreatedAt):
                        query = query.Where(a =>
                            a.CreatedAt >= queryParameters.DateParam.StartDate && a.CreatedAt <= queryParameters.DateParam.EndDate);
                        break;
                    case nameof(CustomerHaveLicenceToApplicationEntity.UpdatedAt):
                        query = query.Where(a =>
                            a.UpdatedAt >= queryParameters.DateParam.StartDate && a.UpdatedAt <= queryParameters.DateParam.EndDate);
                        break;
                    default:
                        throw new ArgumentException("Bad column date name");
                }
            }

            return query;
        }

        public Task<bool> UpdateAsync(UpdateCustomerHasLicenceRequest updateCustomerHasLicenceRequest)
        {
            return _customerHaveLicenceToApplicationRepository.UpdateAsync(_mapper.Map<CustomerHaveLicenceToApplicationEntity>(updateCustomerHasLicenceRequest));
        }
    }
}