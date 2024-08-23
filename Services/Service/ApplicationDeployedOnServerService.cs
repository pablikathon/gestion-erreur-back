using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class ApplicationDeployedOnServerService : IApplicationDeployedOnServerService
    {
        private readonly IApplicationDeployedOnServerRepository _applicationDeployedRepository;
        private readonly IMapper _mapper;

        public ApplicationDeployedOnServerService(IApplicationDeployedOnServerRepository applicationDeployedRepository, IMapper mapper)
        {
            _applicationDeployedRepository = applicationDeployedRepository;
            _mapper = mapper;
        }

        public Task<bool> DeleteDeployedApplication(string idServer, string idApplication)
        {
            return _applicationDeployedRepository.DeleteAsync(idServer, idApplication);

        }

        public Task<ApplicationDeployedOnServerEntity> DeployedApplicationOnServer(CreateApplicationDeployedRequest createApplicationDeployedRequest)
        {
            return _applicationDeployedRepository.AddAsync(_mapper.Map<ApplicationDeployedOnServerEntity>(createApplicationDeployedRequest));
        }

        public PaginationResponse<ApplicationDeployedOnServerEntity> GetApplicationsDeployed(GenericQueryParameter queryParameters)
        {
            var query = _applicationDeployedRepository.GetAllAsync();
            query = DateSearchQuery(queryParameters, query);
            query = Pagination(queryParameters, query);

            var result = query.ToList();
            return new PaginationResponse<ApplicationDeployedOnServerEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);        }

        internal static IQueryable<ApplicationDeployedOnServerEntity> Pagination(GenericQueryParameter queryParameters,
            IQueryable<ApplicationDeployedOnServerEntity> query)
        {
            if (queryParameters.Pagination.PageNumber.GetHashCode() != 0)
            {
                query = query
                    .Skip((queryParameters.Pagination.PageNumber - 1) * queryParameters.Pagination.PageSize)
                    .Take(queryParameters.Pagination.PageSize);
            }

            return query;
        }

        internal static IQueryable<ApplicationDeployedOnServerEntity> DateSearchQuery(GenericQueryParameter queryParameters,
            IQueryable<ApplicationDeployedOnServerEntity> query)
        {
            if(queryParameters.DateParam != null)
            if (queryParameters.DateParam.StartDate.HasValue && queryParameters.DateParam.EndDate.HasValue)
            {
                switch (queryParameters.DateParam.DateField)
                {
                    case nameof(ApplicationDeployedOnServerEntity.CreatedAt):
                        query = query.Where(a =>
                            a.CreatedAt >= queryParameters.DateParam.StartDate && a.CreatedAt <= queryParameters.DateParam.EndDate);
                        break;
                    case nameof(ApplicationDeployedOnServerEntity.UpdatedAt):
                        query = query.Where(a =>
                            a.UpdatedAt >= queryParameters.DateParam.StartDate && a.UpdatedAt <= queryParameters.DateParam.EndDate);
                        break;
                    default:
                        throw new ArgumentException("Bad column date name");
                }
            }

            return query;
        }

        public Task<bool> UpdateDeployedApplicationDeployed(UpdateApplicationDeployedRequest updateApplicationDeployed)
        {
            return _applicationDeployedRepository.UpdateAsync(_mapper.Map<ApplicationDeployedOnServerEntity>(updateApplicationDeployed));
        }
    }
}