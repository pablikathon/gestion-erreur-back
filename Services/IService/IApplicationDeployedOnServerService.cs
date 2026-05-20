using Domain.DTO.Applications;

using Services.Models.Command;
using Services.Models.Common;
namespace Services
{
    public interface IApplicationDeployedOnServerService
    {
        PaginationResponse<ApplicationDeployed> GetApplicationsDeployed(
            GenericQueryParameter queryParameters);

        Task<ApplicationDeployed> DeployedApplicationOnServer(
            CreateApplicationDeployedCommand createApplication);

        Task<Boolean> UpdateDeployedApplicationDeployed(UpdateApplicationDeployedCommand updateApplicationDeployed);
        Task<Boolean> DeleteDeployedApplication(string id_application, string id_server);
    }
}
