using Persist.Entities;
using Services.Models.Common;
using Services.Models.Req;
namespace Services
{
    public interface IApplicationService
    {
        PaginationResponse<ApplicationEntity> GetApplications(QueryParameters queryParameters);
        Task<ApplicationEntity> CreateApplication(CreateApplicationRequest createApplication);        
        Task<Boolean> UpdateApplication( UpdateApplicationRequest UpdateApplicationRequest);
        Task<Boolean> DeleteApplication( string id);

    }
}