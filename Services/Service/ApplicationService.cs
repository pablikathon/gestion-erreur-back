using System.ComponentModel.DataAnnotations;
using AutoMapper;
using exception.Message;
using Persist.Entities;
using Persist.Entities.BaseTable;
using Repositories;
using Services.Extension;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository ApplicationRepository, IMapper mapper)
        {
            _applicationRepository = ApplicationRepository;
            _mapper = mapper;
        }

        public PaginationResponse<ApplicationEntity> GetApplications(QueryParameters queryParameters)
        {
            var query = _applicationRepository.GetApplications();
            if (queryParameters.SearchParam != null)
                query = query.TextSearch(queryParameters.SearchParam);
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.SortBy(queryParameters.Sort);
            query = query.Pagination(queryParameters.Pagination);

            var result = query.ToList();
            return new PaginationResponse<ApplicationEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }

        public async Task<ApplicationEntity> CreateApplication(CreateApplicationRequest createApplication)
        {
            var validation = new ValidationContext(createApplication);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(createApplication, validation, validationResults, true);
            if (isValid)
                return await _applicationRepository.AddAsync(_mapper.Map<ApplicationEntity>(createApplication));
            throw new ArgumentException(TypoMessage.ObjectNotValid);
        }

        public async Task<Boolean> UpdateApplication(UpdateApplicationRequest updateApplication)
        {
            return await _applicationRepository.UpdateAsync(_mapper.Map<ApplicationEntity>(updateApplication));
        }

        public async Task<Boolean> DeleteApplication(string id)
        {
            return await _applicationRepository.DeleteAsync(id);
        }
    }
}