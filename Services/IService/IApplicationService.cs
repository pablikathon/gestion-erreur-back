using Domain.Applications;

using Services.Models.Command;
using Services.Models.Common;

namespace Services
{
    public interface IApplicationService
    {
        PaginationResponse<Application> GetApplications(QueryParameters queryParameters);
        Task<Application> CreateApplication(CreateApplicationCommand createApplication);
        Task<Boolean> UpdateApplication(UpdateApplicationCommand UpdateApplicationCommand);
        Task<Boolean> DeleteApplication(string id);
    }
}
