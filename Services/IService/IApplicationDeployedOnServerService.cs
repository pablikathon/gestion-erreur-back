using Persist.Entities.JoiningTable;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface IApplicationDeployedOnServerService
    {
        PaginationResponse<ApplicationDeployedOnServerEntity> GetApplicationsDeployed(
            GenericQueryParameter queryParameters);

        Task<ApplicationDeployedOnServerEntity> DeployedApplicationOnServer(
            CreateApplicationDeployedRequest createApplication);

        Task<Boolean> UpdateDeployedApplicationDeployed(UpdateApplicationDeployedRequest updateApplicationDeployed);
        Task<Boolean> DeleteDeployedApplication(string id_application, string id_server);
    }
}