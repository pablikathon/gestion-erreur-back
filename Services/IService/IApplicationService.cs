using Persist.Entities.Application;

using Services.Models.Command;
using Services.Models.Common;

namespace Services
{
    public interface IApplicationService
    {
        PaginationResponse<ApplicationEntity> GetApplications(QueryParameters queryParameters);
        Task<ApplicationEntity> CreateApplication(CreateApplicationCommand createApplication);
        Task<Boolean> UpdateApplication(UpdateApplicationCommand UpdateApplicationCommand);
        Task<Boolean> DeleteApplication(string id);
    }
}
