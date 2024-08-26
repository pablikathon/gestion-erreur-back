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
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.Pagination(queryParameters.Pagination);

            var result = query.ToList();
            return new PaginationResponse<CustomerHaveLicenceToApplicationEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);        }



        public Task<bool> UpdateAsync(UpdateCustomerHasLicenceRequest updateCustomerHasLicenceRequest)
        {
            return _customerHaveLicenceToApplicationRepository.UpdateAsync(_mapper.Map<CustomerHaveLicenceToApplicationEntity>(updateCustomerHasLicenceRequest));
        }
    }
}