using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;
using Repositories;
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
        public async Task<PaginationResponse<ApplicationEntity>> GetApplications(QueryParameters queryParameters)
        {
            var query = _applicationRepository.GetApplications();
            if (!String.IsNullOrEmpty(queryParameters.SearchTerm) && !String.IsNullOrWhiteSpace(queryParameters.SearchTerm))
            {
                switch (queryParameters.SearchColumn)
                {
                    case nameof(ApplicationEntity.Title):
                        query = query.Where(a => a.Title.ToLower().Equals(queryParameters.SearchTerm.ToLower()));
                        break;
                    default:
                        throw new ArgumentException("Bad column name");
                }
            }

            if (queryParameters.StartDate.HasValue && queryParameters.EndDate.HasValue)
            {
                switch (queryParameters.DateField)
                {
                    case nameof(ApplicationEntity.CreatedAt):
                        query = query.Where(a => a.CreatedAt >= queryParameters.StartDate && a.CreatedAt <= queryParameters.EndDate);
                        break;
                    case nameof(ApplicationEntity.UpdatedAt):
                        query = query.Where(a => a.UpdatedAt >= queryParameters.StartDate && a.UpdatedAt <= queryParameters.EndDate);
                        break;
                    default:
                        throw new ArgumentException("Bad column date name");
                }
            }
            if (!String.IsNullOrEmpty(queryParameters.Sort.SortBy) && !String.IsNullOrWhiteSpace(queryParameters.Sort.SortBy))
            {
                switch (queryParameters.Sort.SortBy)
                {
                    case nameof(ApplicationEntity.Title):
                        query = queryParameters.Sort.Ascending ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title);
                        break;
                    case nameof(ApplicationEntity.CreatedAt):
                        query = queryParameters.Sort.Ascending ? query.OrderBy(a => a.CreatedAt) : query.OrderByDescending(a => a.Title);
                        break;
                }
            }
            if (queryParameters.Pagination.PageNumber.GetHashCode() != 0)
            {
                query = query
                .Skip((queryParameters.Pagination.PageNumber - 1) * queryParameters.Pagination.PageSize)
                .Take(queryParameters.Pagination.PageSize);
            }

            var result = query.ToList();
            return new PaginationResponse<ApplicationEntity>(result, result.Count, queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }

        public async Task<ApplicationEntity> CreateApplication(CreateApplicationRequest createApplication)
        {

            return  await _applicationRepository.AddAsync(_mapper.Map<ApplicationEntity>(createApplication));
        }
        public async Task<Boolean>  UpdateApplication(UpdateApplicationRequest updateApplication)
        {

            return await _applicationRepository.UpdateAsync(_mapper.Map<ApplicationEntity>(updateApplication));
        }
        public async Task<Boolean>  DeleteApplication(string id)
        {

            return await _applicationRepository.DeleteAsync(id);
        }
    }
    
}