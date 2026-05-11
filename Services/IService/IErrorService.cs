using Persist.Entities.BaseTable;

using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface IErrorService
    {
        Task<bool> AddAsync(CreateErrorCommand errorRequest);
        int UpdateErrors(UpdateErroCommand errorRequest);
        Task<Boolean> DeleteAsync(string idErreur);
        PaginationResponse<ErrorForACustommerStatsResponse> GetErrorsForACustommerAgregate(QueryParameters queryParameters, string custommerId);
        PaginationResponse<ErrorEntity> GetErrorsForACustommer(QueryParameters queryParameters, GetErrorCommand errorRequest);
    }
}
