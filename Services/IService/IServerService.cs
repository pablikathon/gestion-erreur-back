using Persist.Entities.BaseTable;

using Presentation.Models.Req;

using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface IServerService
    {
        PaginationResponse<ServerEntity> GetServers(QueryParameters queryParameters);
        Task<ServerEntity> CreateServer(CreateServerCommand createServerCommand);
        Task<Boolean> UpdateServer(UpdateServerCommand updateServerCommand);
        Task<Boolean> DeleteServer(string id);
    }
}
