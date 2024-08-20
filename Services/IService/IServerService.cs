using Persist.Entities;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface IServerService
    {
        PaginationResponse<ServerEntity> GetServers(QueryParameters queryParameters);
        Task<ServerEntity> CreateServer(CreateServerRequest createServerRequest);
        Task<Boolean> UpdateServer(UpdateServerRequest updateServerRequest);
        Task<Boolean> DeleteServer(string id);
    }
}