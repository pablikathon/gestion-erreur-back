using System.ComponentModel.DataAnnotations;
using AutoMapper;
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
        public PaginationResponse<ApplicationEntity> GetApplications(QueryParameters queryParameters)
        {
            var query = _applicationRepository.GetApplications();
            query = TextSearchQuery(queryParameters, query);
            query = DateSearchQuery(queryParameters, query);
            query = SortQuery(queryParameters, query);
            query = Pagination(queryParameters, query);

            var result = query.ToList();
            return new PaginationResponse<ApplicationEntity>(result, result.Count, queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }

        internal static IQueryable<ApplicationEntity> SortQuery(QueryParameters queryParameters, IQueryable<ApplicationEntity> query)
        {
            if (!String.IsNullOrEmpty(queryParameters.Sort.SortBy) && !String.IsNullOrWhiteSpace(queryParameters.Sort.SortBy))
            {
                switch (queryParameters.Sort.SortBy)
                {
                    case nameof(ApplicationEntity.Title):
                        query = queryParameters.Sort.Ascending ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title);
                        break;
                    case nameof(ApplicationEntity.CreatedAt):
                        query = queryParameters.Sort.Ascending ? query.OrderBy(a => a.CreatedAt) : query.OrderByDescending(a => a.CreatedAt);
                        break;
                    case nameof(ApplicationEntity.UpdatedAt):
                        query = queryParameters.Sort.Ascending ? query.OrderBy(a => a.UpdatedAt) : query.OrderByDescending(a => a.UpdatedAt);
                        break;
                }
            }

            return query;
        }
        internal static IQueryable<ApplicationEntity> Pagination(QueryParameters queryParameters, IQueryable<ApplicationEntity> query)
        {
            if (queryParameters.Pagination.PageNumber.GetHashCode() != 0)
            {
                query = query
                .Skip((queryParameters.Pagination.PageNumber - 1) * queryParameters.Pagination.PageSize)
                .Take(queryParameters.Pagination.PageSize);
            }

            return query;
        }
        internal static IQueryable<ApplicationEntity> DateSearchQuery(QueryParameters queryParameters, IQueryable<ApplicationEntity> query)
        {
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

            return query;
        }

        internal static IQueryable<ApplicationEntity> TextSearchQuery(QueryParameters queryParameters, IQueryable<ApplicationEntity> query)
        {
            if (!String.IsNullOrEmpty(queryParameters.SearchTerm) && !String.IsNullOrWhiteSpace(queryParameters.SearchTerm))
            {
                switch (queryParameters.SearchColumn)
                {
                    case nameof(ApplicationEntity.Title):
                        query = query.Where(a => a.Title.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
                        break;
                    default:
                        throw new ArgumentException("Bad column name");

                }
            }

            return query;
        }

        public async Task<ApplicationEntity> CreateApplication(CreateApplicationRequest createApplication)
        {
            var validation = new ValidationContext(createApplication);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(createApplication, validation, validationResults, true);
            if (isValid)
                return await _applicationRepository.AddAsync(_mapper.Map<ApplicationEntity>(createApplication));
            throw new ArgumentException("not valid object");

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