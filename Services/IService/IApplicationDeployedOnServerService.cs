using Persist.Entities.JoiningTable;

using Services.Models.Command;
using Services.Models.Common;
namespace Services
{
    public interface IApplicationDeployedOnServerService
    {
        PaginationResponse<ApplicationDeployedOnServerEntity> GetApplicationsDeployed(
            GenericQueryParameter queryParameters);

        Task<ApplicationDeployedOnServerEntity> DeployedApplicationOnServer(
            CreateApplicationDeployedCommand createApplication);

        Task<Boolean> UpdateDeployedApplicationDeployed(UpdateApplicationDeployedCommand updateApplicationDeployed);
        Task<Boolean> DeleteDeployedApplication(string id_application, string id_server);
    }
}
