using Persist.Entities.BaseTable;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public interface IErrorService
    {
        Task<bool> AddAsync(CreateErrorRequest errorRequest);
        int UpdateErrors(UpdateErroRequest errorRequest);
        Task<Boolean> DeleteAsync(string idErreur);
        PaginationResponse<ErrorForACustommerStatsResponse> GetErrorsForACustommerAgregate(QueryParameters queryParameters, string custommerId);
        PaginationResponse<ErrorEntity> GetErrorsForACustommer(QueryParameters queryParameters, GetErrorRequest errorRequest);
    }
}