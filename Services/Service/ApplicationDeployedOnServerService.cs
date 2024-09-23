using AutoMapper;
using Persist.Entities.JoiningTable;
using Repositories;
using Services.Extension;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class ApplicationDeployedOnServerService : IApplicationDeployedOnServerService
    {
        private readonly IApplicationDeployedOnServerRepository _applicationDeployedRepository;
        private readonly IMapper _mapper;

        public ApplicationDeployedOnServerService(IApplicationDeployedOnServerRepository applicationDeployedRepository,
            IMapper mapper)
        {
            _applicationDeployedRepository = applicationDeployedRepository;
            _mapper = mapper;
        }

        public Task<bool> DeleteDeployedApplication(string idServer, string idApplication)
        {
            return _applicationDeployedRepository.DeleteAsync(idServer, idApplication);
        }

        public Task<ApplicationDeployedOnServerEntity> DeployedApplicationOnServer(
            CreateApplicationDeployedRequest createApplicationDeployedRequest)
        {
            return _applicationDeployedRepository.AddAsync(
                _mapper.Map<ApplicationDeployedOnServerEntity>(createApplicationDeployedRequest));
        }

        public PaginationResponse<ApplicationDeployedOnServerEntity> GetApplicationsDeployed(
            GenericQueryParameter queryParameters)
        {
            var query = _applicationDeployedRepository.GetAllAsync();
            query = query.Pagination(queryParameters.Pagination);
            query = query.DateSearchQuery(queryParameters.DateParam);

            var result = query.ToList();
            return new PaginationResponse<ApplicationDeployedOnServerEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }


        public Task<bool> UpdateDeployedApplicationDeployed(UpdateApplicationDeployedRequest updateApplicationDeployed)
        {
            return _applicationDeployedRepository.UpdateAsync(
                _mapper.Map<ApplicationDeployedOnServerEntity>(updateApplicationDeployed));
        }
    }
}