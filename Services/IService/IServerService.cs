using Persist.Entities.BaseTable;


using Services.Models.Command;
using Services.Models.Common;

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
